using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
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
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IDatabase context;
        private readonly IMapper mapper;

        public ItemController(IDatabase myDatabase, IMapper mapper)
        {
            this.context = myDatabase;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ItemDto[]), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] string filter = null, int top = 100, int skip = 0)
        {
            var item = context.Item
                .Where(w => filter == null || w.Descricao.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<ItemDto>(mapper.ConfigurationProvider);

            return Ok(item);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute]int id)
        {
            var item = context.Beneficiario
                .SingleOrDefault(s => s.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<ItemDto>(item);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddITem([FromBody] Item item)
        {
            var newItem = mapper.Map<Item>(item);
            newItem = await context.InsertAsync(newItem);

            // 201 retorna em "location" o diretório do método de onde faz o get
            return CreatedAtAction(nameof(GetId), new { Id = newItem.Id }, mapper.Map<ItemDto>(newItem));
        }
    }
}
