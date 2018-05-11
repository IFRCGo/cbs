using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.GreetingGenerators.Queries
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

        public GreetingHistory Query => _collection.FindSync(g => g.PhoneNumber.Equals(PhoneNumber)).FirstOrDefault();

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

        public GreetingHistory Query => _collection.FindAsync(g => g.PhoneNumber.Equals(PhoneNumber)).Result.FirstOrDefault(); //TODO: Safe?
    }
}