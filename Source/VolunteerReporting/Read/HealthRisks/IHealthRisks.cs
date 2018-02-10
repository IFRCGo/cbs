using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRisks
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);
        Guid GetIdFromReadableId(int readbleId);
        void Save(HealthRisk dataCollector);
        void Remove(HealthRisk healthRisk);
    }
}
