using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.HealthRisks
{
    public interface IHealthRisks : IExtendedReadModelRepositoryFor<HealthRisk>
    {
        IEnumerable<HealthRisk> GetAll();

        HealthRisk GetById(Guid id);

        HealthRisk GetByReadableId(int readableId);

        HealthRiskId GetIdFromReadableId(int readbleId);
        void SaveHealthRisk(Guid id, int readableId, string name);
        UpdateResult UpdateHealthRisk(Guid id, int readableId, string name);
    }
}
