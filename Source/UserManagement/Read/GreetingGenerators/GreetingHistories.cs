using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistories : IGreetingHistories
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<GreetingHistory> _collection;

        public GreetingHistories(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<GreetingHistory>("GreetingHistories");
        }

        public async Task<IEnumerable<GreetingHistory>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task<GreetingHistory> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.Id == id)).SingleOrDefault();
        }

        public async Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber)
        {
            return (await _collection.FindAsync(d => d.PhoneNumber == phoneNumber)).SingleOrDefault();
        }
       
        public async Task Remove(Guid id)
        {
            var filter = Builders<GreetingHistory>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task Remove(string phoneNumber)
        {
            var filter = Builders<GreetingHistory>.Filter.Eq(c => c.PhoneNumber, phoneNumber);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task Save(GreetingHistory greetingHistory)
        {
            var filter = Builders<GreetingHistory>.Filter.Eq(c => c.Id, greetingHistory.Id);
            await _collection.ReplaceOneAsync(filter, greetingHistory, new UpdateOptions { IsUpsert = true });
        }
    }
}
