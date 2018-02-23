using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers
{
    public class StaffUsers : IReadCollection<StaffUser>
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<StaffUser> _collection;

        public StaffUsers(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<StaffUser>("StaffUser");
        }
        public async Task<StaffUser> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(s => s.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<StaffUser>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(s => s.Id == id);
        }

        public async Task Save(StaffUser obj)
        {
            await _collection.ReplaceOneAsync(s => s.Id == obj.Id, obj, new UpdateOptions{IsUpsert = true});
        }
    }
}
