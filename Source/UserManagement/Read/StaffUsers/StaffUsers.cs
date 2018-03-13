using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;
using Concepts;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public class StaffUsers : IStaffUsers
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUsers(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<BaseUser>("StaffUsers");
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

        public async Task<T> GetByIdAsync<T>(Guid id) where T : BaseUser
        {
            var user = (await _collection.FindAsync(_ => _.StaffUserId == id)).FirstOrDefault();

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

        public IEnumerable<T> GetAll<T>() where T : BaseUser
        {
            return _collection.AsQueryable().OfType<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseUser
        {
            var filter = Builders<BaseUser>.Filter.OfType<T>();
            var cursor = await _collection.FindAsync(filter);
            var res = await cursor.ToListAsync();
            //TODO: This should be safe..
            return res.Cast<T>().ToList();

        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(_ => _.StaffUserId == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(_ => _.StaffUserId == id);
        }

        public void Save<T>(T dataCollector) where T : BaseUser
        {
            _collection.ReplaceOne(_ => _.StaffUserId == dataCollector.StaffUserId, dataCollector, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync<T>(T dataCollector) where T : BaseUser
        {
            await _collection.ReplaceOneAsync(_ => _.StaffUserId == dataCollector.StaffUserId, dataCollector, new UpdateOptions { IsUpsert = true });
        }
    }
}
