using System;

namespace Read.HealthRiskObjects
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        void Save(HealthRisk entity);
    }
}