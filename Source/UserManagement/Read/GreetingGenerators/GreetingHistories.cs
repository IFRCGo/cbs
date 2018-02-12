using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistories : IGreetingHistories
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistories(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
        }

        public GreetingHistory GetByPhoneNumber(string phoneNumber)
        {
            return _collection.Find(d => d.PhoneNumber == phoneNumber).SingleOrDefault();
        }

        public void RemovePhoneNumber(string phoneNumber)
        {
            var filter = Builders<GreetingHistory>.Filter.Eq(c => c.PhoneNumber, phoneNumber);
            _collection.DeleteOne(filter);
        }

        public void Save(GreetingHistory greetingHistory)
        {
            var filter = Builders<GreetingHistory>.Filter.Eq(c => c.Id, greetingHistory.Id);
            _collection.ReplaceOne(filter, greetingHistory, new UpdateOptions { IsUpsert = true });
        }
    }
}
