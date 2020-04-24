using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
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
    [Route("doadores")]
    public class DoadorController : ControllerBase
    {
        // Note Old Posts
        private readonly IDatabase context;
        private readonly IMapper mapper;
        public DoadorController(IDatabase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DoadorDto[]), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] string filter = null, int top = 100, int skip = 0)
        {
            var doador = context.Doador
                .Where(w => filter == null || w.Nome.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<DoadorDto>(mapper.ConfigurationProvider);

            return Ok(doador);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoadorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetId([FromRoute]int id)
        {
            var doador = context.Doador
                .SingleOrDefault(s => s.Id == id);

            if (doador == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<DoadorDto>(doador);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoador([FromBody] Doador doador)
        {
            var newDoador = mapper.Map<Doador>(doador);
            newDoador.DataCriacao = DateTime.Now;
            newDoador.DataModificacao = DateTime.Now;
            newDoador = await context.InsertAsync(newDoador);

            // 201 retorna em "location" o diretório do método de onde faz o get
            return CreatedAtAction(nameof(GetId), new { Id = newDoador.Id }, mapper.Map<DoadorDto>(newDoador));
        }
    }
}
