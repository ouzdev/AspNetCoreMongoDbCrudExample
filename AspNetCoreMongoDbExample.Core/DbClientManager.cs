using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AspNetCoreMongoDbExample.Core
{
    public class DbClientManager : IDbClientService
    {
        private readonly IMongoCollection<Shipwrecks> _shipwrecks;
        public DbClientManager(IOptions<ShipwrecksDbConfig> shipwrecksDbConfig)
        {
            var client = new MongoClient(shipwrecksDbConfig.Value.ConnectionStrings);
            var database = client.GetDatabase(shipwrecksDbConfig.Value.DatabaseName);
            _shipwrecks = database.GetCollection<Shipwrecks>(shipwrecksDbConfig.Value.CollectionName);
        }
        public IMongoCollection<Shipwrecks> GetShipwrecksCollection() => _shipwrecks;
    }
}
