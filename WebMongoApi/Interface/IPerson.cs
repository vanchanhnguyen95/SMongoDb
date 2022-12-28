using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMongoApi.Models;


namespace WebMongoApi.Interface
{
    public interface IPerson
    {
        IMongoCollection<Person> personCollection { get; }
        void CreatePerson(Person personData);
        Person GetPerson(Person personData);
        Person GetPersonByFirstName(Person personData);
        Task<List<Person>> GetPersonLikeFirstName(Person personData);
    }
}
