using System;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryById : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryById(IMongoDatabase database, Guid greetingHistoryId)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            GreetingHistoryId = greetingHistoryId;
        }

        public Guid GreetingHistoryId { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindSync(g => g.DataCollectorId == GreetingHistoryId);

    }

    public class GreetingHistoryByIdAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryByIdAsync(IMongoDatabase database, Guid greetingHistoryId)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            GreetingHistoryId = greetingHistoryId;
        }

        public Guid GreetingHistoryId { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindAsync(g => g.DataCollectorId == GreetingHistoryId).Result; //TODO: Safe?
    }
}