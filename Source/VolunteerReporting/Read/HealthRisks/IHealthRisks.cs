using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;
using Concepts.HealthRisk;

namespace Read.HealthRisks
{
    public interface IHealthRisks : IExtendedReadModelRepositoryFor<HealthRisk>
    {
        IEnumerable<HealthRisk> GetAll();

        HealthRisk GetById(HealthRiskId id);

        HealthRisk GetByReadableId(HealthRiskReadableId readableId);

        HealthRiskId GetIdFromReadableId(HealthRiskReadableId readableId);
        void SaveHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
        UpdateResult UpdateHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
    }
}
