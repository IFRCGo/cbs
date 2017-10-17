using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRiskFeatures
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);        
        void Save(HealthRisk dataCollector);
    }
}
