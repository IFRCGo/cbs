using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<DataCollector> GetAllDataCollectors()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public DataCollector GetById(Guid id)
        {
            return _collection.Find(d => d.Id == id).SingleOrDefault();
        }

        public void Save(DataCollector dataCollector)
        {
            var filter = Builders<DataCollector>.Filter.Eq(c => c.Id, dataCollector.Id);
            _collection.ReplaceOne(filter, dataCollector, new UpdateOptions { IsUpsert = true });
        }
    }
}
