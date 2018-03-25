using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryByPhoneNumber : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryByPhoneNumber(IMongoDatabase database, string phoneNumber)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindSync(g => g.PhoneNumber.Equals(PhoneNumber));

    }

    public class GreetingHistoryByPhoneNumberAsync : IQueryFor<GreetingHistory>
    {
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistoryByPhoneNumberAsync(IMongoDatabase database, string phoneNumber)
        {
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; }

        public IAsyncCursor<GreetingHistory> Query => _collection.FindAsync(g => g.PhoneNumber.Equals(PhoneNumber)).Result; //TODO: Safe?
    }
}