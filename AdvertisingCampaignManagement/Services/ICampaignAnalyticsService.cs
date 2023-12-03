namespace AdvertisingCampaignManagement.Services
{
    public interface ICampaignAnalyticsService
    {
        int GetClickCountForCampaign(string campaignId);
        double GetConversionRateForCampaign(string campaignId);
    }
}
