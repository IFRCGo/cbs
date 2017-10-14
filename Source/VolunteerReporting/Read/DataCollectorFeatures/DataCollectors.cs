using System;
using MongoDB.Driver;

namespace Read
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