using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiWorkshop.Api.Data;
using RestApiWorkshop.Api.Models;
using RestApiWorkshop.Api.TransferObjects;

namespace RestApiWorkshop.Api.Controllers
{
    [Route("tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMyDatabase myDatabase;
        private readonly IMapper mapper;

        public TagController(IMyDatabase myDatabase, IMapper mapper)
        {
            this.myDatabase = myDatabase;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string filter = null, [FromQuery] int top = 100, [FromQuery] int skip = 0)
        {
            var tags = myDatabase.Tags
                .Where(a => filter == null || a.Value.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<TagDto>(mapper.ConfigurationProvider);

            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var tag = await myDatabase.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<TagDto>(tag);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagDto tag)
        {
            var newTag = mapper.Map<Tag>(tag);

            newTag.Id = await myDatabase.Tags.MaxAsync(a => a.Id) + 1;

            myDatabase.Tags.Add(newTag);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetId), new { id = newTag.Id }, mapper.Map<TagDto>(newTag));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TagDto tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            var oldTag = await myDatabase.Tags.FindAsync(id);
            if (oldTag == null)
            {
                return NotFound();
            }

            oldTag.Value = tag.Value;

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tag = await myDatabase.Tags.FindAsync(id);
            if (tag == null)
            {
                return NoContent();
            }

            myDatabase.Tags.Remove(tag);

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }
    }
}