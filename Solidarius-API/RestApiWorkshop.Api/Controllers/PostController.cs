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
    [Route("posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMyDatabase myDatabase;
        private readonly IMapper mapper;

        public PostController(IMyDatabase myDatabase, IMapper mapper)
        {
            this.myDatabase = myDatabase;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts([FromQuery] string filter = null, [FromQuery] int top = 100, [FromQuery] int skip = 0)
        {
            var posts = myDatabase.Posts
                .Include(a => a.Tags)
                .Where(a => filter == null || a.Content.Contains(filter) || a.Tags.Any(b => b.Value.Contains(filter)))
                .Skip(skip)
                .Take(top)
                .ProjectTo<PostDto>(mapper.ConfigurationProvider);

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            var post = await myDatabase.Posts
                .Include(a => a.Tags)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<PostDto>(post);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] PostDto post)
        {
            var newPost = mapper.Map<Post>(post);

            newPost.Id = await myDatabase.Posts.MaxAsync(a => a.Id) + 1;

            myDatabase.Posts.Add(newPost);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, mapper.Map<PostDto>(newPost));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] PostDto post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var oldPost = await myDatabase.Posts.FindAsync(id);
            if (oldPost == null)
            {
                return NotFound();
            }

            oldPost.Content = post.Content;
            oldPost.Title = post.Title;

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var post = await myDatabase.Posts.FindAsync(id);
            if (post == null)
            {
                return NoContent();
            }

            myDatabase.Posts.Remove(post);

            await myDatabase.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/tags")]
        public async Task<IActionResult> GetTags([FromRoute] int id)
        {
            if (!await myDatabase.Posts.AnyAsync(a => a.Id == id))
            {
                return NotFound();
            }

            var tags = myDatabase.Posts
                .Where(a => a.Id == id)
                .SelectMany(a => a.Tags)
                .ProjectTo<TagDto>(mapper.ConfigurationProvider);

            return Ok(tags);
        }

        [HttpPost("{id}/tags")]
        public async Task<IActionResult> PostTag([FromRoute] int id, [FromBody] TagDto tag)
        {
            var post = await myDatabase.Posts
                .Include(a => a.Tags)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            var newTag = mapper.Map<Tag>(tag);

            newTag.Id = await myDatabase.Tags.MaxAsync(a => a.Id) + 1;

            post.Tags.Add(newTag);

            await myDatabase.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTags), new { id = post.Id }, null);
        }

        [HttpDelete("{postId}/tags/{tagId}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int postId, [FromRoute] int tagId)
        {
            var tag = await myDatabase.Posts
                .Where(a => a.Id == postId)
                .SelectMany(a => a.Tags)
                .SingleOrDefaultAsync(a => a.Id == tagId);

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