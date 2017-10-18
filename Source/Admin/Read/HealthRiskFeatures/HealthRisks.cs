using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.HealthRiskFeatures
{
    public class HealthRisks : IHealthRisks
    {
        private IMongoDatabase _database;
        private IMongoCollection<HealthRisk> _collection;

        public HealthRisks(IMongoDatabase database)

        {
            _database = database;
            _collection = database.GetCollection<HealthRisk>("HealthRisk");
        }

        public IEnumerable<HealthRisk> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            var filter = Builders<HealthRisk>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Save(HealthRisk healthRisk)
        {
            _collection.InsertOne(healthRisk);
        }
    }
}
