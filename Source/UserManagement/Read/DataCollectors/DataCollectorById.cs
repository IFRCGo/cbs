using System;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public DataCollectorById(IMongoDatabase database, Guid dataCollectorId)
        {
            _collection = database.GetCollection<DataCollector>("DataCollectors");
            DataCollectorId = dataCollectorId;
        }

        public Guid DataCollectorId { get; }

        public IAsyncCursor<DataCollector> Query => _collection.FindSync(d => d.Id == DataCollectorId);
    }

    public class DataCollectorByIdAsync : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public DataCollectorByIdAsync(IMongoCollection<DataCollector> collection, Guid dataCollectorId)
        {
            _collection = collection;
            DataCollectorId = dataCollectorId;
        }

        public Guid DataCollectorId { get; }

        public IAsyncCursor<DataCollector> Query => _collection.FindAsync(d => d.Id == DataCollectorId).Result; //Todo: Safe?
    }

}