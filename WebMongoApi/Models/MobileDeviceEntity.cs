using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoApi.Models
{
    public class MobileDeviceEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Color { get; set; }
        public double Cost { get; set; }
    }
}
