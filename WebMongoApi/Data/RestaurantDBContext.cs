using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongoApi.Interface;
using WebMongoApi.Models;

namespace WebMongoApi.Data
{
    public class RestaurantDBContext : IRestaurant
    {
        public readonly IMongoDatabase _db;

        public RestaurantDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Restaurant> restaurantCollection
            => _db.GetCollection<Restaurant>("restaurants");


        public async Task<Restaurant> GetRestaurant(double lat, double lng)
        {
            try
            {
                // Instantiate builder
                var builder = Builders<Restaurant>.Filter;
                // Set center point to Magnolia Bakery on Bleecker Street
                var point = GeoJson.Point(GeoJson.Position(40.7358879 , - 74.005));

                // Create geospatial query that searches for restaurants at most 10,000 meters away,
                // and at least 2,000 meters away from Magnolia Bakery (AKA, our center point)
                var filter = builder.Near(x => x.Location, point);

                var res = await _db.GetCollection<Restaurant>("restaurants").Find(filter).FirstOrDefaultAsync();

                //var point = GeoJson.Point(GeoJson.Geographic(lng, lat));
                //var locationQuery = new FilterDefinitionBuilder<Restaurant>().Near(tag => tag.Location, point,
                //    1); //fetch results that are within a 50 metre radius of the point we're searching.
                //var query = _db.GetCollection<Restaurant>("restaurants").Find(locationQuery).Limit(10); //Limit the query to return only the top 10 results.
                return res;
            }
            catch (Exception ex)
            {
                //do something;
                return null;
            }
            return null;
        }
        public Task<List<Restaurant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Restaurant>> ListPoint()
        {
            var lst = await _db.GetCollection<Restaurant>("restaurants").Find(a => true).ToListAsync();
            return lst;
        }

        public void NearExampleRestaurant()
        {
            // Instantiate builder
            var builder = Builders<Restaurant>.Filter;
            // Set center point to Magnolia Bakery on Bleecker Street
            var point = GeoJson.Point(GeoJson.Position(-74.005, 40.7358879));

            // Create geospatial query that searches for restaurants at most 10,000 meters away,
            // and at least 2,000 meters away from Magnolia Bakery (AKA, our center point)
            var filter = builder.Near(x => x.Location, point, maxDistance: 10000, minDistance: 2000);
        }

        private void GetListPoint()
        {
            
        }
    }
}
