using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pet.Project.Profile.Domain.Models;

namespace Pet.Project.Profile.Infrastructure.Database
{
    public class MongoContext
    {
        private readonly MongoClient _client;

        public MongoContext(IOptions<DatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            Database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database { get; }
    }
}