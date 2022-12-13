using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var postsDb = await _context.Posts.ToListAsync();
            var posts = postsDb.FindAll(c => c.IsDeleted == false);

            return posts.Count > 0 ? Ok(posts) : NoContent();
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        [AllowAnonymous]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPost(int id, PostInput postInput)
        {
            Post postUpdated = postInput.ToInput();
            postUpdated.Id = id;

            _context.Entry(postUpdated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return BadRequest("Post não existe.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Post>> PostPost(PostInput postInput)
        {
            var newPost = postInput.ToInput();
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetPost", newPost);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return BadRequest();
            }

            post.IsDeleted = true;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
