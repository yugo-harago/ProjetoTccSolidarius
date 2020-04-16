using System.Linq;
using System.Net;
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
    [Route("blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMyDatabase myDatabase;
        private readonly IMapper mapper;

        public BlogController(IMyDatabase myDatabase, IMapper mapper)
        {
            this.myDatabase = myDatabase;
            this.mapper = mapper;
        }

        /// <summary>
        /// Listagem de blogs
        /// </summary>
        /// <remarks>
        /// <para>
        /// GET /blogs?filter=Eu&amp;skip=10&amp;top=15
        /// </para>
        /// <para>
        /// A razão para essa documentação não ter funcionado anteriormente foi a utilização do E comercial (&amp;) sem sua codificação especial.
        /// </para>
        /// <para>
        /// Você pode utilizar a query desse recurso para filtrar e paginar os resultados de acordo com sua necessidade
        /// </para>
        /// </remarks>
        /// <param name="filter">Filtrar blogs por nome do autor</param>
        /// <param name="top">Limita a quantidade de registros</param>
        /// <param name="skip">Pula a quantidade de registros</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BlogDto[]), (int)HttpStatusCode.OK)]
        public IActionResult GetBlog([FromQuery] string filter = null, [FromQuery] int top = 100, [FromQuery] int skip = 0)
        {
            var blogs = myDatabase.Blogs
                .Include(a => a.Author)
                .Include(a => a.Posts)
                .ThenInclude(a => a.Tags)
                .Where(a => filter == null || a.Author.Name.Contains(filter))
                .Skip(skip)
                .Take(top)
                .ProjectTo<BlogDto>(mapper.ConfigurationProvider);

            return Ok(blogs);
        }

        /// <summary>
        /// Pega um blog específico
        /// </summary>
        /// <remarks>
        ///     GET /blogs/1234
        /// </remarks>
        /// <param name="id">Identificação do Blog</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            var blog = await myDatabase.Blogs
                .Include(a => a.Author)
                .Include(a => a.Posts)
                .ThenInclude(a => a.Tags)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<BlogDto>(blog);

            return Ok(dto);
        }

        /// <summary>
        /// Cria um blog na coleção
        /// </summary>
        /// <remarks>
        ///     POST /blogs
        /// </remarks>
        /// <param name="blog">Dados do blog</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BlogDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostBlog([FromBody] BlogDto blog)
        {
            var newBlog = mapper.Map<Blog>(blog);

            newBlog.Id = await myDatabase.Blogs.MaxAsync(a => a.Id) + 1;

            myDatabase.Blogs.Add(newBlog);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = newBlog.Id }, mapper.Map<BlogDto>(newBlog));
        }

        /// <summary>
        /// Atualiza um blog
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Identificação do blog</param>
        /// <param name="blog">Dados do blog</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutBlog([FromRoute] int id, [FromBody] BlogDto blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            var oldBlog = await myDatabase.Blogs.FindAsync(id);
            if (oldBlog == null)
            {
                return NotFound();
            }

            oldBlog.Url = blog.Url;

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um blog
        /// </summary>
        /// <param name="id">Identificação do blog</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteBlog([FromRoute] int id)
        {
            var blog = await myDatabase.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NoContent();
            }

            myDatabase.Blogs.Remove(blog);

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/author")]
        [ProducesResponseType(typeof(AuthorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            var blog = await myDatabase.Blogs
                .Include(a => a.Author)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            var author = mapper.Map<AuthorDto>(blog.Author);

            return Ok(author);
        }

        [HttpPut("{id}/author")]
        [ProducesResponseType(typeof(AuthorDto), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> PutAuthor([FromRoute] int id, [FromBody] AuthorDto author)
        {
            var blog = await myDatabase.Blogs
                .Include(a => a.Author)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            var newAuthor = await myDatabase.Authors.FindAsync(author.Id);
            if (newAuthor == null)
            {
                return Conflict();
            }

            blog.Author = newAuthor;

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/posts")]
        [ProducesResponseType(typeof(PostDto[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPosts([FromRoute] int id, [FromQuery] string[] tags = null)
        {
            if (!await myDatabase.Blogs.AnyAsync(a => a.Id == id))
            {
                return NotFound();
            }

            if (tags?.Length == 0)
                tags = null;

            var posts = myDatabase.Blogs
                .Include(a => a.Posts)
                .ThenInclude(a => a.Tags)
                .Where(a => a.Id == id)
                .SelectMany(a => a.Posts)
                .Where(a => tags == null || a.Tags.Any(b => tags.Contains(b.Value)))
                .ProjectTo<PostDto>(mapper.ConfigurationProvider);

            return Ok(posts);
        }

        [HttpGet("{blogId}/posts/{postId}")]
        [ProducesResponseType(typeof(PostDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPost([FromRoute] int blogId, [FromRoute] int postId)
        {
            var post = await myDatabase.Blogs
                .Include(a => a.Posts)
                .ThenInclude(a => a.Tags)
                .Where(a => a.Id == blogId)
                .SelectMany(a => a.Posts)
                .SingleOrDefaultAsync(a => a.Id == postId);

            if (post == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<PostDto>(post);

            return Ok(dto);
        }

        [HttpPost("{id}/posts")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostPosts([FromRoute] int id, [FromBody] PostDto post)
        {
            var blog = await myDatabase.Blogs
                .Include(a => a.Author)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            var newPost = mapper.Map<Post>(post);

            newPost.Id = await myDatabase.Posts.MaxAsync(a => a.Id) + 1;

            blog.Posts.Add(newPost);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { blogId = blog.Id, postId = newPost.Id }, null);
        }
    }
}