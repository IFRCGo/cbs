using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read
{
    public class Users : IStaffUsers
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<StaffUser> _staffUserCollection;

        public Users(IMongoDatabase database)
        {
            _database = database;
            _staffUserCollection = database.GetCollection<StaffUser>("StaffUser");
        }

       
        public async Task<StaffUser> GetByIdAsync(Guid id)
        {
            var user = await _staffUserCollection.FindAsync(c => c.Id == id);

            return user.SingleOrDefault();

        }

        public async Task<IEnumerable<StaffUser>> GetAllAsync()
        {
            var users = await _staffUserCollection.FindAsync(_ => true);

            return await users.ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            var filter = Builders<StaffUser>.Filter.Eq(c => c.Id, id);
            await _staffUserCollection.DeleteOneAsync(filter);
        }

        public async Task Save(StaffUser staffUser)
        {
            await _staffUserCollection.ReplaceOneAsync(c => c.Id == staffUser.Id, staffUser, new UpdateOptions {IsUpsert = true});
        }
    }
}