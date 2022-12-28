using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMongoApi.Models;

namespace WebMongoApi.Interface
{
    public interface IRestaurant
    {
        IMongoCollection<Restaurant> restaurantCollection { get; }
        void NearExampleRestaurant();
        Task<List<Restaurant>> GetAll();
        Task<Restaurant> GetRestaurant(double lat, double lng);
    }
}
