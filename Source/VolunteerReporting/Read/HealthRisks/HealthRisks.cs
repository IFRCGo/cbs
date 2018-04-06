using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Concepts;

namespace Read.HealthRisks
{
    public class HealthRisks : IHealthRisks
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<HealthRisk> _collection;

        public HealthRisks(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<HealthRisk>("HealthRisk");
        }

        public async Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            var filter = Builders<HealthRisk>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public HealthRisk GetById(Guid id)
        {
            return _collection.Find(d => d.Id == id).SingleOrDefault();
        }

        public HealthRisk GetByReadableId(int readableId)
        {
            return _collection.Find(d => d.ReadableId == readableId).Single();
        }

        public HealthRiskId GetIdFromReadableId(int readbleId)
        {
            var healthRiskId = _collection.Find(d => d.ReadableId == readbleId).Project(_ => _.Id).FirstOrDefault();
            return healthRiskId;
        }

        public void Save(HealthRisk healthRisk)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRisk.Id);
            _collection.ReplaceOne(filter, healthRisk, new UpdateOptions { IsUpsert = true });
        }

        public void Remove(Guid healthRiskId)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRiskId);
            _collection.DeleteOne(filter);
        }

        public async Task SaveAsync(HealthRisk healthRisk)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRisk.Id);
            await  _collection.ReplaceOneAsync(filter, healthRisk, new UpdateOptions { IsUpsert = true });
        }

        public async Task RemoveAsync(Guid healthRiskId)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRiskId);
            await _collection.DeleteOneAsync(filter);
        }

    }
}
