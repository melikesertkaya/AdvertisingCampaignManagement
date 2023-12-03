using AdvertisingCampaignManagement.Models;
using AdvertisingCampaignManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingCampaignManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService) 
        { 
            _campaignService = campaignService;
        }
        [HttpGet("GetAllCampaigns")]
        public ActionResult<IEnumerable<Campaign>> GetAllCampaigns()
        {
            var campaigns = _campaignService.GetAllCampaigns();
            return Ok(campaigns);
        }
        [HttpGet("GetCampaignById/{id}")]
        public ActionResult<Campaign> GetCampaignById(string id) 
        { 
            var campaign=_campaignService.GetCampaignById(id);
            if(campaign == null) 
                return NotFound();
            return Ok(campaign);
        }
        [HttpPost("CreateCampaign")]
        public IActionResult CreateCampaign([FromBody] Campaign campaign)
        {
            _campaignService.CreateCampaign(campaign);
            return CreatedAtAction(nameof(GetCampaignById), new {id=campaign.Id},campaign);
        }
        [HttpPut("UpdateCampaign/{id}")]
        public IActionResult UpdateCampaign(string id, [FromBody] Campaign campaign)
        {
           
                var existingCampaign = _campaignService.GetCampaignById(id);
                if (existingCampaign == null)
                    return NotFound();
                _campaignService.UpdateCampaign(id, campaign);
                return NoContent();
            
           
        }
        [HttpDelete("DeleteCampaign/{id}")]
        public IActionResult DeleteCampaign(string id)
        {
            var campaign = _campaignService.GetCampaignById(id);
            if (campaign == null)
                return NotFound();
            _campaignService.DeleteCampaign(id);
            return NoContent();
        }
    }
}
