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
        Guid GetIdFromReadableId(int readbleId);
        Task Save(HealthRisk dataCollector);
        Task Remove(Guid healthRiskId);
        
    }
}
