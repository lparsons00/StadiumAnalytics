using Microsoft.AspNetCore.Mvc;
using StadiumAnalytics.StadiumAnalytics.Application.Queries;
using StadiumAnalytics.StadiumAnalytics.Application.Services;

namespace StadiumAnalytics.StadiumAnalytics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;
        
        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAnalytics(
            [FromQuery] string? gate = null,
            [FromQuery] string? type = null,
            [FromQuery] DateTime? startTime = null,
            [FromQuery] DateTime? endTime = null)
        {
            try
            {
                var query = new GetAnalyticsQuery(gate, type, startTime, endTime);
                var results = await _analyticsService.GetAnalyticsAsync(query);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
