using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace WebMongoApi.Models
{
    public class Restaurant
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }
        public string Name { get; set; }
    }
}
