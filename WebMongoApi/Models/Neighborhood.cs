using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace WebMongoApi.Models
{
    public class Neighborhood
    {
        public ObjectId Id { get; set; }
        public GeoJsonPoint<GeoJson2DCoordinates> Geometry { get; set; }
        public string Name { get; set; }
    }
}
