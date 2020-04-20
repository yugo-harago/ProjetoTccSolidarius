using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
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
    [Route("mediadores")]
    public class MediadorController : ControllerBase
    {
        private readonly IDatabase context;
        private readonly IMapper mapper;
        public MediadorController(IDatabase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MediadorDto[]), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] string filter = null, int top = 100, int skip = 0)
        {
            var mediador = context.Mediador
                .Where(w => filter == null || w.Nome.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<MediadorDto>(mapper.ConfigurationProvider);

            return Ok(mediador);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute]int id)
        {
            var mediador = context.Mediador
                .SingleOrDefault(s => s.Id == id);

            if (mediador == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<MediadorDto>(mediador);

            return Ok(dto);
        }
    }
}
