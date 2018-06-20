using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Concepts;
using Infrastructure.Read.MongoDb;
using Concepts.HealthRisk;

namespace Read.HealthRisks
{
    public class HealthRisks : ExtendedReadModelRepositoryFor<HealthRisk>,
        IHealthRisks
    {
        public HealthRisks(IMongoDatabase database)
            : base(database, database.GetCollection<HealthRisk>("HealthRisk"))
        {
        }

        public IEnumerable<HealthRisk> GetAll()
        {
            return GetMany(_ => true);
        }
        public HealthRisk GetById(HealthRiskId id)
        {
            return GetOne(_ => _.Id == id);
        }
        public HealthRisk GetByReadableId(HealthRiskReadableId readableId)
        {
            return GetOne(_ => _.ReadableId == readableId);
        }
        public HealthRiskId GetIdFromReadableId(HealthRiskReadableId readbleId)
        {
            return GetByReadableId(readbleId).Id;
        }
        public void SaveHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name)
        {
            Update(new HealthRisk(id)
            {
                Name = name,
                ReadableId = readableId
            });
        }

        public UpdateResult UpdateHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name)
        {
            return Update(d => d.Id == id, Builders<HealthRisk>.Update.Combine(
                Builders<HealthRisk>.Update.Set(h => h.Name, name),
                Builders<HealthRisk>.Update.Set(h => h.ReadableId, readableId))
                );
        }
    }
}
