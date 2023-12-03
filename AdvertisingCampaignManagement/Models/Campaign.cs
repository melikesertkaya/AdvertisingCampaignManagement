using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdvertisingCampaignManagement.Models
{
    public class Campaign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClickCount { get; set; }
        public double ConversionRate { get; set; }
    }
}
