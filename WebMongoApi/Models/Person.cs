using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace WebMongoApi.Models
{
    public class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location
        { get; private set; }
        public void SetLocation(double lon, double lat) => SetPosition(lon, lat);

        private void SetPosition(double lon, double lat)
        {
            Latitude = lat;
            Longitude = lon;
            Location = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(lon, lat));
        }
    }
}
