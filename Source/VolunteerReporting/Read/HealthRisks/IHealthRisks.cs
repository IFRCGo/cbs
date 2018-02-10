using System;
using System.Threading.Tasks;

namespace Read.HealthRisks
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);
        Guid GetIdFromReadableId(int readbleId);
        Task Save(HealthRisk dataCollector);
        Task Remove(Guid healthRiskId);
    }
}
