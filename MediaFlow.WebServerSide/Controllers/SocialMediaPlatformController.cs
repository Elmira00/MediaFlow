using MediaFlow.Entities.Models;
using MediaFlow.WebServerSide.Dtos;
using MediaFlow.WebServerSide.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaPlatformController : ControllerBase
    {
        private readonly ISocialMediaPlatformService _socialMediaPlatformService;

        public SocialMediaPlatformController(ISocialMediaPlatformService socialMediaPlatformService)
        {
            _socialMediaPlatformService = socialMediaPlatformService;
        }

        // GET: api/SocialMediaPlatform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialMediaPlatform>>> GetAll()
        {
            var platforms = await _socialMediaPlatformService.GetAllPlatforms();
            return Ok(platforms);
        }

        // GET: api/SocialMediaPlatform/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocialMediaPlatform>> GetById(int id)
        {
            var platform = await _socialMediaPlatformService.GetPlatformById(id);
            if (platform == null)
            {
                return NotFound();
            }
            return Ok(platform);
        }

        // POST: api/SocialMediaPlatform
        [HttpPost]
        public async Task<ActionResult<SocialMediaPlatform>> Create(SocialMediaPlatformDto platformDto)
        {
            var platform = await _socialMediaPlatformService.CreatePlatform(platformDto);
            return CreatedAtAction("GetById", new { id = platform.PlatformId }, platform);
        }

        // PUT: api/SocialMediaPlatform/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SocialMediaPlatformDto platformDto)
        {
            if (id != platformDto.PlatformId)
            {
                return BadRequest();
            }

            var result = await _socialMediaPlatformService.UpdatePlatform(platformDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SocialMediaPlatform/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _socialMediaPlatformService.DeletePlatform(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
