using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidariusAPI.Api.Data;
using SolidariusAPI.Api.Enum;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IDatabase context;
        private readonly IMapper mapper;

        public PedidoController(IDatabase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PedidoDto[]), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] string filter = null, int top = 100, int skip = 0)
        {
            var pedido = context.Pedido
                .Where(w => filter == null || w.Descricao.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<PedidoDto>(mapper.ConfigurationProvider);

            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute]int id)
        {
            var pedido = context.Pedido
                .SingleOrDefault(s => s.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<PedidoDto>(pedido);

            return Ok(dto);
        }

        [HttpPost("{beneficiarioId}")]
        public async Task<IActionResult> AddPedido([FromRoute] int beneficiarioId, [FromBody] Pedido pedido)
        {
            var newPedido = mapper.Map<Pedido>(pedido);
            newPedido.FeitoPor = context.Beneficiario.Find(beneficiarioId);
            newPedido.DataCriacao = DateTime.Now;
            newPedido.DataModificacao = DateTime.Now;
            newPedido.Estado = Estado.Aguardando;
            foreach (var item in newPedido.Item)
            {
                await context.InsertAsync(item);
            }
            newPedido = await context.InsertAsync(newPedido);

            // 201 retorna em "location" o diretório do método de onde faz o get
            return CreatedAtAction(nameof(GetId), new { Id = newPedido.Id }, mapper.Map<PedidoDto>(newPedido));
        }

        [HttpGet("user/{userTypeInt}/{userId}")]
        public IActionResult GetByUser([FromRoute]int userTypeInt, int userId)
        {
            var userType = (UserType)userTypeInt;
            if (userType == UserType.Beneficiario)
            {
                var pedidos = context.Pedido.Where(w => w.FeitoPor.Id == userId).ProjectTo<PedidoDto>(mapper.ConfigurationProvider);
                return Ok(pedidos);
            }
            if(userType == UserType.Doador)
            {
                var pedidos = context.Pedido.Where(w => w.AceitoPor.Id == userId).ProjectTo<PedidoDto>(mapper.ConfigurationProvider);
                return Ok(pedidos);
            }
            if(userType == UserType.Mediador)
            {
                var pedidos = context.Pedido.ProjectTo<PedidoDto>(mapper.ConfigurationProvider);
                return Ok(pedidos);
            }
            return BadRequest();
        }

        [HttpPut("donate/{userId}/{pedidoId}")]
        public IActionResult Donate([FromRoute]int userId, int pedidoId)
        {
            var doador = context.Usuario.Find(userId);
            if (doador == null)
            {
                return BadRequest();
            }
            var pedido = context.Pedido.Find(pedidoId);
            if (pedido == null)
            {
                return NotFound();
            }
            //var beneficiario = context.Beneficiario.Find(pedido.FeitoPor.Id);
            pedido.AceitoPor = doador;
            pedido.Estado = Enum.Estado.EmAndamento;
            var notificacao = new Notificacao();
            var mediador = context.Mediador.FirstOrDefault();
            notificacao.Para = mediador;
            notificacao.Por = doador;
            notificacao.Visto = false;
            notificacao.Confirmado = false;
            notificacao.Pedido = pedido;
            notificacao.Descricao = string.Format("Pedido de {0} aceito por {1}.", pedido.FeitoPor.Nome, doador.Nome);
            context.Update(pedido);
            context.Insert(notificacao);

            return NoContent();
        }
        [HttpPut("recieved-donation")]
        public IActionResult Recieved([FromBody]int mediadorId, int notificacaoId)
        {
            var mediador = context.Mediador.Find(mediadorId);
            if (mediador == null)
            {
                return BadRequest();
            }
            var notificacaoAceita = context.Notificacao.Find(notificacaoId);
            notificacaoAceita.Confirmado = true;
            context.Update(notificacaoAceita);
            var notificacao = new Notificacao();
            notificacao.Para = context.Beneficiario.Find(notificacaoAceita.Pedido.FeitoPor.Id);
            notificacao.Por = context.Mediador.Find(mediadorId);
            notificacao.Descricao = "Pedido aceito. Receba na recepção o seu pedido.";
            notificacao.Pedido.Estado = Enum.Estado.EsperandoParaRetirar;
            notificacao.Visto = false;
            notificacao.Confirmado = false;
            context.Update(notificacao);

            return NoContent();
        }
    }
}
