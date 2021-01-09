using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCoreMongoDbExample.Core
{
    [BsonIgnoreExtraElements]
    public class Shipwrecks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("feature_type")]
        public string FeatureType { get; set; }

        [BsonElement("chart")]
        public string Chart { get; set; }

        [BsonElement("latdec")]
        public double Latitude { get; set; }

        [BsonElement("londec")]
        public double Longitude { get; set; }

        [BsonElement("watlev")]
        public string Watlev { get; set; }

        //[BsonElement("coordinates")]
        //public List<double> Coordinates { get; set; }

    }
}
