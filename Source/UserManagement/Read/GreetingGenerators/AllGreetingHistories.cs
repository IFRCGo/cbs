using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class AllGreetingHistories : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public AllGreetingHistories(IMongoCollection<GreetingHistory> collection)
        {
            _collection = collection;

        }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindSync(_ => true);

    }

    public class AllGreetingHistoriesAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public AllGreetingHistoriesAsync(IMongoCollection<GreetingHistory> collection)
        {
            _collection = collection;

        }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindAsync(_ => true).Result; //TODO: Safe?
    }
}
