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
    [Route("authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMyDatabase myDatabase;
        private readonly IMapper mapper;

        public AuthorController(IMyDatabase myDatabase, IMapper mapper)
        {
            this.myDatabase = myDatabase;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors([FromQuery] string filter = null, [FromQuery] int top = 100, [FromQuery] int skip = 0)
        {
            var authors = myDatabase.Authors
                .Where(a => filter == null || a.Name.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<AuthorDto>(mapper.ConfigurationProvider);

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            var author = await myDatabase.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<AuthorDto>(author);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthor([FromBody] AuthorDto author)
        {
            var newAuthor = mapper.Map<Author>(author);

            newAuthor.Id = await myDatabase.Authors.MaxAsync(a => a.Id) + 1;

            myDatabase.Authors.Add(newAuthor);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, mapper.Map<AuthorDto>(newAuthor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor([FromRoute] int id, [FromBody] AuthorDto author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var oldAuthor = await myDatabase.Authors.FindAsync(id);
            if (oldAuthor == null)
            {
                return NotFound();
            }

            oldAuthor.Name = author.Name;

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            var author = await myDatabase.Authors.FindAsync(id);
            if (author == null)
            {
                return NoContent();
            }

            myDatabase.Authors.Remove(author);

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }
    }
}