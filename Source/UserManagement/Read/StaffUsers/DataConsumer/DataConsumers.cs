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
        public DataConsumers(
            IMongoDatabase database
        )
        {
            _database = database;
            _collection = database.GetCollection<DataConsumer>("DataConsumer");
        }
        public async Task<DataConsumer> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<DataConsumer>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task Save(DataConsumer obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}