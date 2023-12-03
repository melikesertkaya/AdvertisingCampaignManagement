using AdvertisingCampaignManagement.Context;
using AdvertisingCampaignManagement.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AdvertisingCampaignManagement.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly MongoDbContext _context;
        public CampaignService(MongoDbContext context)
        {
            _context = context;
        }
        public void CreateCampaign(Campaign campaign)
        {
            campaign.Id = ObjectId.GenerateNewId().ToString();
            campaign.CreatedDate = DateTime.Now;
            _context.Campaigns.InsertOne(campaign);
        }

        public void DeleteCampaign(string id)
        {
           _context.Campaigns.DeleteOne(c=>c.Id==id.ToString());
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            var campaigns= _context.Campaigns.Find(_ => true).ToList();
            if(campaigns.Count==0)
                return Enumerable.Empty<Campaign>();
            return campaigns;

        }

        public Campaign GetCampaignById(string id)
        {
            return _context.Campaigns.Find(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateCampaign(string id, Campaign campaign)
        {
            campaign.Id=id.ToString();
            _context.Campaigns.ReplaceOne(c=>c.Id==id, campaign);
        }
    }
}
