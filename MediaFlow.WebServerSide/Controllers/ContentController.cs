using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _service;

        public ContentController(IContentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContent()
        {
            var content = await _service.GetAll();
            return Ok(content);
        }

        [HttpPost]
        public async Task<IActionResult> AddContent(Content content)
        {
            await _service.Add(content);
            return CreatedAtAction(nameof(GetAllContent), content);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent(int id, Content content)
        {
            if (id != content.ContentId) return BadRequest();
            await _service.Update(content);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
