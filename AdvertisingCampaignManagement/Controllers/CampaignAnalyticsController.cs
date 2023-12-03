using AdvertisingCampaignManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingCampaignManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignAnalyticsController : ControllerBase
    {
        private readonly ICampaignAnalyticsService _campaignAnalyticsService;
        public CampaignAnalyticsController(ICampaignAnalyticsService campaignAnalyticsService)
        {
            _campaignAnalyticsService = campaignAnalyticsService;
        }

        [HttpGet("clicks")]
        public IActionResult GetClickCount(string campaignId)
        {
            var clickCount = _campaignAnalyticsService.GetClickCountForCampaign(campaignId);
            return Ok(clickCount);
        }

        [HttpGet("conversion-rate")]
        public IActionResult GetConversionRate(string campaignId)
        {
            var conversionRate = _campaignAnalyticsService.GetConversionRateForCampaign(campaignId);
            return Ok(conversionRate);
        }
    }
}
