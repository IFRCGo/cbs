using System;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryById : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryById(IMongoCollection<GreetingHistory> collection, Guid greetingHistoryId)
        {
            _collection = collection;
            GreetingHistoryId = greetingHistoryId;
        }

        public Guid GreetingHistoryId { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindSync(g => g.GreetingHistoryId == GreetingHistoryId);

    }

    public class GreetingHistoryByIdAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryByIdAsync(IMongoCollection<GreetingHistory> collection, Guid greetingHistoryId)
        {
            _collection = collection;
            GreetingHistoryId = greetingHistoryId;
        }

        public Guid GreetingHistoryId { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindAsync(g => g.GreetingHistoryId == GreetingHistoryId).Result; //TODO: Safe?
    }
}