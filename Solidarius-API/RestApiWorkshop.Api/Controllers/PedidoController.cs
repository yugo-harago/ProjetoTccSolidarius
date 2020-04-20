using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidariusAPI.Api.Data;
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
    }
}
