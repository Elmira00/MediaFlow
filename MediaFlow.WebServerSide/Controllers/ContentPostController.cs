using MediaFlow.Core.Abstract;
using MediaFlow.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentPostController : ControllerBase
    {
        private readonly IContentPostService _contentPostService;

        public ContentPostController(IContentPostService contentPostService)
        {
            _contentPostService = contentPostService;
        }

        // GET: api/contentpost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentPost>>> GetAllContentPosts()
        {
            var contentPosts = await _contentPostService.GetAllContentPostsAsync();
            return Ok(contentPosts);
        }

        // GET: api/contentpost/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentPost>> GetContentPost(int id)
        {
            var contentPost = await _contentPostService.GetContentPostByIdAsync(id);
            if (contentPost == null)
            {
                return NotFound();
            }
            return Ok(contentPost);
        }

        // POST: api/contentpost
        [HttpPost]
        public async Task<ActionResult<ContentPost>> CreateContentPost(ContentPost contentPost)
        {
            var createdContentPost = await _contentPostService.CreateContentPostAsync(contentPost);
            return CreatedAtAction(nameof(GetContentPost), new { id = createdContentPost.PostId }, createdContentPost);
        }

        // PUT: api/contentpost/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContentPost(int id, ContentPost contentPost)
        {
            if (id != contentPost.PostId)
            {
                return BadRequest();
            }

            var result = await _contentPostService.UpdateContentPostAsync(contentPost);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/contentpost/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentPost(int id)
        {
            var result = await _contentPostService.DeleteContentPostAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
