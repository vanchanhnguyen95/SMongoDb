using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebMongoApi.Interface;
using WebMongoApi.Models;

namespace WebMongoApi.Data
{
    public class PersonDBContext : IPerson
    {
        public readonly IMongoDatabase _db;

        public PersonDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Person> personCollection
             => _db.GetCollection<Person>("person");

        public void CreatePerson(Person personData)
        {
            personCollection.InsertOne(personData);
        }

        public Person GetPerson(Person personData)
        {
            Person item = personCollection.Find(a => a.Location == personData.Location).Single();
            return item;
        }

        public Person GetPersonByFirstName(Person personData)
        {
            var filter = Builders<Person>.Filter.Eq(c => c.FirstName, personData.FirstName);

            Person item = personCollection.Find(filter).FirstOrDefault();
            return item;
        }

        public async Task<List<Person>> GetPersonLikeFirstName(Person personData)
        {
            var queryExpr = new BsonRegularExpression(new Regex(personData.FirstName, RegexOptions.None));

            var builder = Builders<Person>.Filter;
            var filter = builder.Regex("FirstName", queryExpr);

            var matchedDocuments = await personCollection.FindSync(filter).ToListAsync();
            return matchedDocuments;
        }

    }
}
