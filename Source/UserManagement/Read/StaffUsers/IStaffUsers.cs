using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public interface IStaffUsers
    {
        T GetById<T>(Guid id)
            where T : BaseUser;
        Task<T> GetByIdAsync<T>(Guid id)
            where T : BaseUser;

        IEnumerable<T> GetAll<T>()
            where T : BaseUser;
        Task<IEnumerable<T>> GetAllAsync<T>()
            where T : BaseUser;

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save<T>(T dataCollector)
            where T : BaseUser;
        Task SaveAsync<T>(T dataCollector)
            where T : BaseUser;

        void UpdateOne<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : BaseUser;
        //void UpdateOneAdmin(FilterDefinition<Admin> filter, UpdateDefinition<Admin> update);
        //void UpdateOneDataConsumer(FilterDefinition<DataConsumer> filter, UpdateDefinition<DataConsumer> update);
        //void UpdateOneDataCoordinator(FilterDefinition<DataCoordinator> filter, UpdateDefinition<DataCoordinator> update);
        //void UpdateOneDataOwner(FilterDefinition<DataOwner> filter, UpdateDefinition<DataOwner> update);
        //void UpdateOneDataVerifier(FilterDefinition<DataVerifier> filter, UpdateDefinition<DataVerifier> update);
        //void UpdateOneSystemConfigurator(FilterDefinition<SystemConfigurator> filter, UpdateDefinition<SystemConfigurator> update);
    }
}