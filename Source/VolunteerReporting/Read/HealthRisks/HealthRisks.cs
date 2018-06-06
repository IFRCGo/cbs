using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Concepts;
using Infrastructure.Read.MongoDb;

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

        public async Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            return await GetManyAsync(_ => true);
        }

        public HealthRisk GetById(Guid id)
        {
            return GetOne(_ => _.Id == id);
        }

        public Task<HealthRisk> GetByIdAsync(Guid id)
        {
            return GetOneAsync(_ => _.Id == id);
        }

        public HealthRisk GetByReadableId(int readableId)
        {
            return GetOne(_ => _.ReadableId == readableId);
        }

        public Task<HealthRisk> GetByReadableIdAsync(int readableId)
        {
            return GetOneAsync(_ => _.ReadableId == readableId);
        }

        public HealthRiskId GetIdFromReadableId(int readbleId)
        {
            return GetByReadableId(readbleId).Id;
        }

        public async Task<HealthRiskId> GetIdFromReadableIdAsync(int readbleId)
        {
            return (await GetByReadableIdAsync(readbleId)).Id;
        }

        public void SaveHealthRisk(Guid id, int readableId, string name)
        {
            Update(new HealthRisk(id)
            {
                Name = name,
                ReadableId = readableId
            });
        }

        public Task SaveHealthRiskAsync(Guid id, int readableId, string name)
        {
            return UpdateAsync(new HealthRisk(id)
            {
                Name = name,
                ReadableId = readableId
            });
        }

        public UpdateResult UpdateHealthRisk(Guid id, int readableId, string name)
        {
            return Update(d => d.Id == id, Builders<HealthRisk>.Update.Combine(
                Builders<HealthRisk>.Update.Set(h => h.Name, name),
                Builders<HealthRisk>.Update.Set(h => h.ReadableId, readableId))
                );
        }

        public Task<UpdateResult> UpdateHealthRiskAsync(Guid id, int readableId, string name)
        {
            return UpdateAsync(d => d.Id == id, Builders<HealthRisk>.Update.Combine(
                    Builders<HealthRisk>.Update.Set(h => h.Name, name),
                    Builders<HealthRisk>.Update.Set(h => h.ReadableId, readableId))
            );
        }
    }
}
