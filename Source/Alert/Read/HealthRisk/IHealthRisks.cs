using System;

namespace Read.HealthRisk
{
    public interface IHealthRisks
    {
        HealthRisk GetById(Guid id);
        void Save(HealthRisk entity);
    }
}