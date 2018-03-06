using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.DataConsumer
{
    public class DataConsumers : IDataConsumers
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DataConsumer> _collection;

        public DataConsumers(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataConsumer>("DataConsumer");
        }

        public DataConsumer GetById(Guid id)
        {
            return _collection.Find(a => a.StaffUserId == id).SingleOrDefault();
        }

        public async Task<DataConsumer> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.StaffUserId == id)).SingleOrDefault();
        }

        public IEnumerable<DataConsumer> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<DataConsumer>> GetAllAsync()
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

        public void Save(DataConsumer obj)
        {
            _collection.ReplaceOne(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(DataConsumer obj)
        {
            await _collection.ReplaceOneAsync(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}