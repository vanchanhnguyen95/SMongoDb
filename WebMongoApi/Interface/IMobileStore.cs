using MongoDB.Driver;
using System.Collections.Generic;
using WebMongoApi.Models;

namespace WebMongoApi.Interface
{
    public interface IMobileStore
    {
        IMongoCollection<MobileDeviceEntity> mobileDeviceCollection { get; }
        IEnumerable<MobileDeviceEntity> GetAllMobileDevices();
        MobileDeviceEntity GetMobileDeviceDetails(string Name);
        void Create(MobileDeviceEntity mobileDeviceEntityData);
        void Update(string _id,MobileDeviceEntity mobileDeviceEntityData);
        void Delete(string Name);

    }
}
