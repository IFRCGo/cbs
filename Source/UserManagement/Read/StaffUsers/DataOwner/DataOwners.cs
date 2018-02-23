using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.DataOwner
{
    public class DataOwners : IDataOwners
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DataOwner> _collection;
        public DataOwners (
            IMongoDatabase database
        )
        {
            _database = database;
            _collection = database.GetCollection<DataOwner>("DataConsumer");
        }
        public async Task<DataOwner> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<DataOwner>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task Save(DataOwner obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}