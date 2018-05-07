using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Concepts;

namespace Read.HealthRisks
{
    public class HealthRisks : GenericReadModelRepositoryFor<HealthRisk, Guid>,
        IHealthRisks
    {
        public HealthRisks(IMongoDatabase database)
            : base(database, database.GetCollection<HealthRisk>("HealthRisk"))
        {
        }

        public async Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            return await GetManyAsync(_ => true);
        }

        public HealthRisk GetById(Guid id)
        {
            return GetOne(_ => _.Id == id);
        }

        public HealthRisk GetByReadableId(int readableId)
        {
            return GetOne(_ => _.ReadableId == readableId);
        }

        public HealthRiskId GetIdFromReadableId(int readbleId)
        {
            return GetByReadableId(readbleId).Id;
        }
        
    }
}
