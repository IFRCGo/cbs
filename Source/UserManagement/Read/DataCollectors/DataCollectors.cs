using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.DataCollectors
{
    public class DataCollectors : IDataCollectors
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DataCollector> _collection;

        public DataCollectors(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataCollector>("DataCollectors");
        }

        public DataCollector GetById(Guid id)
        {
            return _collection.Find(d => d.DataCollectorId == id).SingleOrDefault();
        }

        public async Task<DataCollector> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.DataCollectorId == id)).SingleOrDefault();
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return _collection.Find(_ => true).ToEnumerable();
        }

        public async Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(c => c.DataCollectorId == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(c => c.DataCollectorId == id);
        }

        public void Save(DataCollector dataCollector)
        {
            _collection.ReplaceOne(d => d.DataCollectorId == dataCollector.DataCollectorId, dataCollector, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(DataCollector dataCollector)
        {
            await _collection.ReplaceOneAsync(d => d.DataCollectorId == dataCollector.DataCollectorId, dataCollector, new UpdateOptions { IsUpsert = true });
        }
    }
}
