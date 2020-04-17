using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    public class MediadorController : ControllerBase
    {
        // Note: Old Tags
        private readonly IMyDatabase context;
        public MediadorController(IMyDatabase context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mediador = context.Mediador
                .ToList();

            return Ok(mediador);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            var mediador = context.Mediador
                .SingleOrDefault(s => s.Id == id);

            return Ok(mediador);
        }
    }
}
