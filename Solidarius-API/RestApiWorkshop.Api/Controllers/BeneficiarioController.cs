using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidariusAPI.Api.Data;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("beneficiarios")]
    public class BeneficiarioController : ControllerBase
    {
        // Note Old Blogs
        private readonly IDatabase context;
        private readonly IMapper mapper;

        public BeneficiarioController(IDatabase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Busca um único beneficiario
        /// </summary>
        /// <remarks>
        ///     Formas de utilizar: Get /beneficiario?filter=Eu&amp;Skip=10&amp;top=20
        /// </remarks>
        /// <param name="filter">utilizado para filtar o nome do beneficiario</param>
        /// <param name="top">É utilizado para buscar apenas um numero especifico de registros</param>
        /// <param name="skip">É utilizado para pular registros</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BeneficiarioDto[]), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] string filter = null, int top = 100, int skip = 0)
        {
            var beneficiarios = context.Beneficiario
                .Where(w => filter == null || w.Nome.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<BeneficiarioDto>(mapper.ConfigurationProvider); //straming com dto //Converte para query de dto

            return Ok(beneficiarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BeneficiarioDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetId([FromRoute]int id)
        {
            var beneficiario = context.Beneficiario
                .SingleOrDefault(s => s.Id == id);

            if(beneficiario == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<BeneficiarioDto>(beneficiario);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBeneficiario([FromBody] Beneficiario beneficiario)
        {
            var newBeneficiario = mapper.Map<Beneficiario>(beneficiario);
            newBeneficiario = await context.InsertAsync(newBeneficiario);

            // 201 retorna em "location" o diretório do método de onde faz o get
            return CreatedAtAction(nameof(GetId), new { Id = newBeneficiario.Id }, mapper.Map<BeneficiarioDto>(newBeneficiario));
        }

        [HttpPut]
        public IActionResult UpdateBlog([FromRoute] int id, [FromBody] Beneficiario beneficiario)
        {
            if (id != beneficiario.Id)
            {
                return BadRequest();
            }

            if (context.Beneficiario.Find(id) == null)
            {
                return NotFound();
            }
            context.Update(beneficiario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var beneficiario = context.Beneficiario.Find(id);
            if (beneficiario == null)
            {
                return NoContent();
            }

            context.Delete(beneficiario);

            return NoContent();
        }

        //[HttpGet("{id}/beneficiario")]
        //public IActionResult GetAuthor([FromRoute] int id)
        //{
        //    var beneficiario = context.Beneficiario
        //        .Include(a => a.Author)
        //        .SingleOrDefault(a => a.Id == id);

        //    if (beneficiario == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(beneficiario.Author);
        //}

        //// Bad Example
        //[HttpGet("{id}/posts/bad-example")]
        //public IActionResult GetPosts_([FromBody] int id)
        //{
        //    var beneficiario = context.Beneficiario
        //        .Include(i => i.Posts)
        //        .ThenInclude(t => t.Tags)
        //        .SingleOrDefault(a => a.Id == id);

        //    if (beneficiario == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(beneficiario.Posts);
        //}

        //[HttpGet("{id}/posts")]
        //public IActionResult GetPosts([FromBody] int id, [FromQuery] string[] tags = null)
        //{
        //    if (context.Blogs.Any(a => a.Id == id))
        //    {
        //        return NotFound();
        //    }

        //    if (tags?.Length == 0)
        //        tags = null;

        //    var posts = context.Blogs
        //        .Include(i => i.Posts)
        //        .ThenInclude(t => t.Tags)
        //        .Where(a => a.Id == id)
        //        .SelectMany(a => a.Posts) //Retorna um queryable de posts
        //        .Where(w => tags == null || w.Tags.Any(a => tags.Contains(a.Value)))
        //        .ToList();
        //        //Sem o to list o framework faz um streaming

        //    return Ok(posts);
        //}

        //[HttpGet("{id}/posts/async")]
        //public async Task<IActionResult> GetPostsQuery([FromBody] int id, [FromQuery] string[] tags = null)
        //{
        //    if (! await context.Blogs.AnyAsync(a => a.Id == id))
        //    {
        //        return NotFound();
        //    }

        //    if (tags?.Length == 0)
        //        tags = null;

        //    var posts = context.Blogs
        //        .Include(i => i.Posts)
        //        .ThenInclude(t => t.Tags)
        //        .Where(a => a.Id == id)
        //        .SelectMany(a => a.Posts) //Retorna um queryable de posts
        //        .Where(w => tags == null || w.Tags.Any(a => tags.Contains(a.Value)))
        //        .ToListAsync();

        //    return Ok(posts);
        //}


    }
}