using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Read.StaffUsers
{
    public class StaffUsersForReading : IStaffUsersForReading
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUsersForReading(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<BaseUser>("StaffUsersForReading");
        }


        public T GetById<T>(Guid id) where T : BaseUser
        {

            var user = _collection.FindSync(_ => _.StaffUserId == id).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFound($"StaffUser with id {id} was not found");
            }
            var result = user as T;

            if (result == null)
            {
                // User is not of request type
                throw new UserNotOfExpectedType($"User with id {id} was is not of type {nameof(T)}");
            }

            return result;
        }

        //public Task<T> GetByIdAsync<T>(Guid id) where T : BaseUser
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<T> GetAll<T>() where T : BaseUser
        {
            return _collection.AsQueryable<BaseUser>().OfType<T>().ToList();
        }

        //public Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseUser
        //{
        //    return _collection.
        //}

        public void Remove(Guid id)
        {
            _collection.DeleteOne(_ => _.StaffUserId == id);
        }

        //public Task RemoveAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Save<T>(T dataCollector) where T : BaseUser
        {
            _collection.ReplaceOne(_ => _.StaffUserId == dataCollector.StaffUserId, dataCollector, new UpdateOptions {IsUpsert = true});
        }

        //public Task SaveAsync<T>(T dataCollector) where T : BaseUser
        //{
        //    throw new NotImplementedException();
        //}

    }
}