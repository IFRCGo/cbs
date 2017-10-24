using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRisks
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);        
        void Save(HealthRisk dataCollector);
    }
}
