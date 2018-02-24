using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.Admin
{
    public class Admins : IAdmins
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Admin> _collection;

        public Admins(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<Admin>("Admin");
        }

        public Admin GetById(Guid id)
        {
            return _collection.Find(a => a.Id == id).SingleOrDefault();
        }

        public async Task<Admin> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public IEnumerable<Admin> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(a => a.Id == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public void Save(Admin obj)
        {
            _collection.ReplaceOne(a => a.Id == obj.Id, obj, new UpdateOptions { IsUpsert = true });
        }

        public async Task SaveAsync(Admin obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions {IsUpsert = true});
        }
    }
}