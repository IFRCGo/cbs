using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.HealthRisks
{
    public interface IHealthRisks
    {
        Task<IEnumerable<HealthRisk>> GetAllAsync();
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);
        HealthRiskId GetIdFromReadableId(int readbleId);
        void Save(HealthRisk dataCollector);
        void Remove(Guid healthRiskId);
        Task SaveAsync(HealthRisk dataCollector);
        Task RemoveAsync(Guid healthRiskId);
        
    }
}
