using MediaFlow.Business.Abstract;
using MediaFlow.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        // GET: api/Analytics
        [HttpGet]
        public async Task<IActionResult> GetAllAnalytics()
        {
            var analytics = await _analyticsService.GetAllAsync();
            return Ok(analytics);
        }

        // GET: api/Analytics/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnalyticsById(int id)
        {
            var analytics = await _analyticsService.GetByIdAsync(id);
            if (analytics == null) return NotFound("Analytics record not found.");
            return Ok(analytics);
        }

        // POST: api/Analytics
        [HttpPost]
        public async Task<IActionResult> CreateAnalytics(Analytics analytics)
        {
            var createdAnalytics = await _analyticsService.AddAsync(analytics);
            return CreatedAtAction(nameof(GetAnalyticsById), new { id = createdAnalytics.AnalyticsId }, createdAnalytics);
        }

        // PUT: api/Analytics/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnalytics(int id, Analytics analytics)
        {
            if (id != analytics.AnalyticsId)
                return BadRequest("ID mismatch.");

            var updatedAnalytics = await _analyticsService.UpdateAsync(analytics);
            if (updatedAnalytics == null) return NotFound("Analytics record not found.");
            return Ok(updatedAnalytics);
        }

        // DELETE: api/Analytics/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytics(int id)
        {
            var result = await _analyticsService.DeleteAsync(id);
            if (!result) return NotFound("Analytics record not found.");
            return NoContent();
        }
    }
}
