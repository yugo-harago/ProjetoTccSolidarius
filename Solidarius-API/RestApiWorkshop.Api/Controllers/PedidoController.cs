using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidariusAPI.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("authors")]
    public class PedidoController : ControllerBase
    {
        // Note: old Authors
        private readonly IMyDatabase context;

        public PedidoController(IMyDatabase context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var pedido = context.Pedido
                .ToList();

            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            var author = context.Pedido
                .SingleOrDefault(s => s.Id == id);

            return Ok(author);
        }
    }
}
