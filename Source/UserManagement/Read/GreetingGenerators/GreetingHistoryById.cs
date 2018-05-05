using System;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryById : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryById(IMongoDatabase database, Guid dataCollectorId)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            DataCollectorId = dataCollectorId;
        }

        public Guid DataCollectorId { get; }

        public GreetingHistory Query => _collection.FindSync(g => g.DataCollectorId == DataCollectorId).FirstOrDefault();

    }

    public class GreetingHistoryByIdAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryByIdAsync(IMongoDatabase database, Guid dataCollectorId)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            DataCollectorId = dataCollectorId;
        }

        public Guid DataCollectorId { get; }

        public GreetingHistory Query => _collection.FindAsync(g => g.DataCollectorId == DataCollectorId).Result.FirstOrDefault(); //TODO: Safe?
    }
}