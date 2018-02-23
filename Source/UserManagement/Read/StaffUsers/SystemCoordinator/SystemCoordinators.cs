using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.StaffUsers.SystemCoordinator
{
    public class SystemCoordinators : ISystemCoordinators
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<SystemCoordinator> _collection;

        public SystemCoordinators (
            IMongoDatabase database
        )
        {
            _database = database;
            _collection = database.GetCollection<SystemCoordinator>("DataConsumer");
        }
        public async Task<SystemCoordinator> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(a => a.Id == id)).SingleOrDefault();
        }

        public async Task<IEnumerable<SystemCoordinator>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }

        public async Task Remove(Guid id)
        {
            await _collection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task Save(SystemCoordinator obj)
        {
            await _collection.ReplaceOneAsync(a => a.Id == obj.Id, obj, new UpdateOptions { IsUpsert = true });
        }
    }
}