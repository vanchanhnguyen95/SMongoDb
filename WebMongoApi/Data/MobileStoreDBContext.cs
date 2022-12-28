using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongoApi.Interface;
using WebMongoApi.Models;

namespace WebMongoApi.Data
{
    public class MobileStoreDBContext : IMobileStore
    {
        public readonly IMongoDatabase _db;

        public MobileStoreDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<MobileDeviceEntity> mobileDeviceCollection
            => _db.GetCollection<MobileDeviceEntity>("mobiledevice");

        public IEnumerable<MobileDeviceEntity> GetAllMobileDevices()
        {
            return mobileDeviceCollection.Find(a => true).ToList();
        }

        public MobileDeviceEntity GetMobileDeviceDetails(string Name)
        {
            return mobileDeviceCollection.Find(m => m.Name == Name).FirstOrDefault();
        }

        public void Create(MobileDeviceEntity mobileDeviceEntityData)
        {
            mobileDeviceCollection.InsertOne(mobileDeviceEntityData);
        }

        public void Update(string _id, MobileDeviceEntity mobileDeviceEntityData)
        {
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<MobileDeviceEntity>.Update
                .Set("Name", mobileDeviceEntityData.Name)
                .Set("Company", mobileDeviceEntityData.Company)
                .Set("Color", mobileDeviceEntityData.Color)
                .Set("Cost", mobileDeviceEntityData.Cost);
            mobileDeviceCollection.UpdateOne(filter, update);
        }

        public void Delete(string Name)
        {
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c.Name, Name);
            mobileDeviceCollection.DeleteOne(filter);
        }

    }
}
