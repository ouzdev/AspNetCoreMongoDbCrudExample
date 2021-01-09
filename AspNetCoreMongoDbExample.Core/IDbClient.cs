using MongoDB.Driver;

namespace AspNetCoreMongoDbExample.Core
{
    public interface IDbClientService
    {
        IMongoCollection<Shipwrecks> GetShipwrecksCollection();
    }
}
