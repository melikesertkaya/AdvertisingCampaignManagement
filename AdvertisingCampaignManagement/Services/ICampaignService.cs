using AdvertisingCampaignManagement.Models;

namespace AdvertisingCampaignManagement.Services
{
    public interface ICampaignService
    {
        IEnumerable<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(string id);
        void CreateCampaign(Campaign campaign);
        void UpdateCampaign(string id,Campaign campaign); 
        void DeleteCampaign(string id);
    }
}
