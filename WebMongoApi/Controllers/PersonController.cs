using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMongoApi.Interface;
using WebMongoApi.Models;

namespace WebMongoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPerson _context;
        public PersonController(IPerson context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CreatePerson")]
        public IActionResult CreatePerson(Person person)
        {
            person.SetLocation(person.Longitude, person.Latitude);
            _context.CreatePerson(person);

            return Ok();
        }

        [HttpGet]
        [Route("GetPerson")]
        public IActionResult GetPerson(Person person)
        {
            person.SetLocation(person.Longitude, person.Latitude);
            Person item = _context.GetPerson(person);

            return Ok(item);
        }

        [HttpGet]
        [Route("GetPersonByFirstName")]
        public IActionResult GetPersonByFirstName(Person person)
        {
            Person item = _context.GetPersonByFirstName(person);

            return Ok(item);
        }

        [HttpGet]
        [Route("GetPersonLikeFirstName")]
        public async Task<IActionResult> GetPersonLikeFirstNameAsync(Person person)
        {
            var item = await _context.GetPersonLikeFirstName(person);

            return Ok(item);
        }
    }
}
