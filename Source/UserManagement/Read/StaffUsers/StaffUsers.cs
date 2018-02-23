using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers
{
    public class StaffUsers : IReadCollection<StaffUser>
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<StaffUser> _collection;

        public StaffUsers(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<StaffUser>("StaffUser");
        }
        public async Task<StaffUser> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StaffUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(StaffUser obj)
        {
            throw new NotImplementedException();
        }
    }
}
