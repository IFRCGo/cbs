using System;

namespace Read.Disease
{
    public interface IHealthRisks
    {
        Read.Disease.HealthRisk GetById(Guid id);
        void Save(Read.Disease.HealthRisk entity);
    }
}