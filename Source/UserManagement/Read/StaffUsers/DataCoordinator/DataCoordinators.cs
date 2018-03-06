using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.DataCoordinator
{
    public class DataCoordinators : IDataCoordinators
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DataCoordinator> _collection;

        public DataCoordinators(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataCoordinator>("DataCoordinator");
        }

        public DataCoordinator GetById(Guid id)
        {
            return _collection.Find(a => a.StaffUserId == id).SingleOrDefault();
        }

        public async Task<DataCoordinator> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.StaffUserId == id)).SingleOrDefault();
        }

        public IEnumerable<DataCoordinator> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<DataCoordinator>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(a => a.StaffUserId == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.StaffUserId == id);
        }

        public void Save(DataCoordinator obj)
        {
            _collection.ReplaceOne(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(DataCoordinator obj)
        {
            await _collection.ReplaceOneAsync(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}