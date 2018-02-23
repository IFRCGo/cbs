using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.DataVerifier
{
    public class DataVerifiers : IDataVerifiers
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DataVerifier> _collection;

        public DataVerifiers (
            IMongoDatabase database
        )
        {
            _database = database;
            _collection = database.GetCollection<DataVerifier>("DataConsumer");
        }
        public async Task<DataVerifier> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<DataVerifier>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task Save(DataVerifier obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}