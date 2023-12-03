namespace AdvertisingCampaignManagement.Services
{
    public class CampaignAnalyticsService:ICampaignAnalyticsService
    {
        private readonly ICampaignService _campaignService;
        public CampaignAnalyticsService(ICampaignService campaignService)
        {
            _campaignService=campaignService;
        }

        public int GetClickCountForCampaign(string campaignId)
        {
            var campaign = _campaignService.GetCampaignById(campaignId);
            return campaign?.ClickCount ?? 0;
        }

        public double GetConversionRateForCampaign(string campaignId)
        {
            var campaign=_campaignService.GetCampaignById(campaignId);
            return campaign?.ConversionRate ?? 0;
        }
    }
}
