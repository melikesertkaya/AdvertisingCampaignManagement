using AdvertisingCampaignManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdvertisingCampaignManagement.Context
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Campaign> Campaigns => _database.GetCollection<Campaign>("Campaigns");
    }
}
