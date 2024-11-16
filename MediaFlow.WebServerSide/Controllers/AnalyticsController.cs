using MediaFlow.Business.Abstract;
using MediaFlow.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _service;

        public AnalyticsController(IAnalyticsService service)
        {
            _service = service;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAnalyticsByAccountId(int accountId)
        {
            var analytics = await _service.GetAnalyticsByAccountId(accountId);
            return Ok(analytics);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnalytics(Analytics analytics)
        {
            await _service.Add(analytics);
            return CreatedAtAction(nameof(GetAnalyticsByAccountId), new { accountId = analytics.AccountId }, analytics);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnalytics(int id, Analytics analytics)
        {
            if (id != analytics.AnalyticsId) return BadRequest();
            await _service.Update(analytics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytics(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
