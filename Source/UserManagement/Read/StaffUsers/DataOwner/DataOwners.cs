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
        public DataOwners (IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataOwner>("DataOwner");
        }

        public DataOwner GetById(Guid id)
        {
            return _collection.Find(a => a.StaffUserId == id).SingleOrDefault();
        }

        public async Task<DataOwner> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.StaffUserId == id)).SingleOrDefault();
        }

        public IEnumerable<DataOwner> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<DataOwner>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(a => a.StaffUserId == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.StaffUserId == id);
        }

        public void Save(DataOwner obj)
        {
            _collection.ReplaceOne(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(DataOwner obj)
        {
            await _collection.ReplaceOneAsync(a => a.StaffUserId == obj.StaffUserId, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}