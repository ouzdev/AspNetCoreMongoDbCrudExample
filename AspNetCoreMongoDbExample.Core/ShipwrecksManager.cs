using MongoDB.Driver;
using System.Collections.Generic;

namespace AspNetCoreMongoDbExample.Core
{
    public class ShipwrecksManager : IShipwrecksService
    {
        private readonly IMongoCollection<Shipwrecks> _shipwrecks;
        public ShipwrecksManager(IDbClientService dbClient)
        {
            _shipwrecks = dbClient.GetShipwrecksCollection();
        }
        public List<Shipwrecks> GetShipwrecks() => _shipwrecks.Find(shipwrecks => true).ToList();
    }
}
