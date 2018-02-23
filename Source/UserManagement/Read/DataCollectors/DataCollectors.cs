using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.DataCollectors
{
    public class DataCollectors : IDataCollectors
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<DataCollector> _collection;

        public DataCollectors(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataCollector>("DataCollector");
        }

        public async Task<DataCollector> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task Save(DataCollector dataCollector)
        {
            var filter = Builders<DataCollector>.Filter.Eq(c => c.Id, dataCollector.Id);
            await _collection.ReplaceOneAsync(filter, dataCollector, new UpdateOptions { IsUpsert = true });
        }
    }
}
