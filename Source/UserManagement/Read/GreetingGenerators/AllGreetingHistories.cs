using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class AllGreetingHistories : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public AllGreetingHistories(IMongoDatabase database)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");

        }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindSync(_ => true);

    }

    public class AllGreetingHistoriesAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public AllGreetingHistoriesAsync(IMongoDatabase database)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");

        }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindAsync(_ => true).Result; //TODO: Safe?
    }
}
