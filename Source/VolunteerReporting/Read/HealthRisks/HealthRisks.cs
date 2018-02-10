using System;
using MongoDB.Driver;

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

        
        public HealthRisk GetById(Guid id)
        {
            return _collection.Find(d => d.Id == id).SingleOrDefault();
        }

        public HealthRisk GetByReadableId(int readableId)
        {
            return _collection.Find(d => d.ReadableId == readableId).Single();
        }

        public Guid GetIdFromReadableId(int readbleId)
        {
            var healthRiskId = _collection.Find(d => d.ReadableId == readbleId).Project(_ => _.Id).FirstOrDefault();
            return healthRiskId;
        }

        public void Save(HealthRisk healthRisk)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRisk.Id);
            _collection.ReplaceOne(filter, healthRisk, new UpdateOptions { IsUpsert = true });
        }
        public void Delete(HealthRisk healthRisk)
        {
            var filter = Builders<HealthRisk>.Filter.Eq(c => c.Id, healthRisk.Id);
            _collection.DeleteOne(filter);
        }

    }
}
