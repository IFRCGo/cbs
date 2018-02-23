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
        public Admins(
            IMongoDatabase database,
            IMongoCollection<Admin> collection
            )
        {
            _database = database;
            collection = database.GetCollection<Admin>("Admin");
        }
        public async Task<Admin> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task Save(Admin obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions {IsUpsert = true});
        }
    }
}