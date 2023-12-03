using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdvertisingCampaignManagement.Models
{
    public class Advertisement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CampaignId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
