using System;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.DataCollectors.Queries
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

        public DataCollector Query => _collection.FindSync(d => d.DataCollectorId == DataCollectorId).FirstOrDefault();
    }

    //public class DataCollectorByIdAsync : IQueryFor<DataCollector>
    //{
    //    private readonly IMongoCollection<DataCollector> _collection;

    //    public DataCollectorByIdAsync(IMongoDatabase database, Guid dataCollectorId)
    //    {
    //        _collection = database.GetCollection<DataCollector>("DataCollectors"); ;
    //        DataCollectorId = dataCollectorId;
    //    }

    //    public Guid DataCollectorId { get; }

    //    public DataCollector Query => _collection.FindAsync(d => d.DataCollectorId == DataCollectorId).Result.FirstOrDefault(); //Todo: Safe?
    //}

}