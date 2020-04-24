using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("notificacao")]
    public class NotificacaoController : ControllerBase
    {
        private readonly IDatabase context;
        private readonly IMapper mapper;

        public NotificacaoController(IDatabase myDatabase, IMapper mapper)
        {
            this.context = myDatabase;
            this.mapper = mapper;
        }

        [HttpGet("get")]
        public IActionResult Get([FromRoute] int userId)
        {
            var notificacoes = context.Notificacao.Where(w => w.Para.Id == userId)
                                    .ProjectTo<NotificacaoDto>(mapper.ConfigurationProvider);
            return Ok(notificacoes);
        }

        [HttpPut]
        public IActionResult UpdateNotificacao([FromBody] Notificacao notificacao)
        {
            if (context.Notificacao.Find(notificacao.Id) == null)
            {
                return NotFound();
            }
            context.Update(notificacao);
            return NoContent();
        }
    }
}
