using System.Collections.Generic;

namespace AspNetCoreMongoDbExample.Core
{
    public interface IShipwrecksService
    {
        List<Shipwrecks> GetShipwrecks();

    }
}
