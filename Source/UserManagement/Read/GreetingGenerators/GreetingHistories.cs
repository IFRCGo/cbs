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

        public IEnumerable<GreetingHistory> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<GreetingHistory>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public GreetingHistory GetById(Guid id)
        {
            return _collection.Find(d => d.DataCollectorId == id).SingleOrDefault();
        }

        public async Task<GreetingHistory> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.DataCollectorId == id)).SingleOrDefault();
        }

        public GreetingHistory GetByPhoneNumber(string phoneNumber)
        {
            return _collection.Find(d => d.PhoneNumber == phoneNumber).SingleOrDefault();
        }

        public async Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber)
        {
            return (await _collection.FindAsync(d => d.PhoneNumber == phoneNumber)).SingleOrDefault();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(g => g.DataCollectorId == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(g => g.DataCollectorId == id);
        }

        public void Remove(string phoneNumber)
        {
            _collection.DeleteOne(g => g.PhoneNumber == phoneNumber);
        }

        public async Task RemoveAsync(string phoneNumber)
        {
            await _collection.DeleteOneAsync(g => g.PhoneNumber == phoneNumber);
        }

        public void Save(GreetingHistory greetingHistory)
        {
            _collection.ReplaceOne(g => g.DataCollectorId == greetingHistory.DataCollectorId, greetingHistory,
                new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(GreetingHistory greetingHistory)
        {
            await _collection.ReplaceOneAsync(g => g.DataCollectorId == greetingHistory.DataCollectorId, greetingHistory, 
                new UpdateOptions { IsUpsert = true });
        }
    }
}
