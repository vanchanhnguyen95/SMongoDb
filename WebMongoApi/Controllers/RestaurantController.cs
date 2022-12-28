using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongoApi.Interface;
using WebMongoApi.Models;

namespace WebMongoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurant _context;
        public RestaurantController(IRestaurant context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public void Get()
        {
            _context.NearExampleRestaurant();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
        [HttpGet]
        [Route("GetRestaurant")]
        public async Task<Restaurant> GetRestaurant()
        {
        //location: { coordinates:[ -74.0259567, 40.6353674 ], type: 'Point' },
            double lat = 40.6353674;
            double lng = -74.0259567;
            return await _context.GetRestaurant(lat, lng);
        }

    }
}
