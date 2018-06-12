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
        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(HealthRiskId id);
        Task<HealthRisk> GetByIdAsync(HealthRiskId id);

        HealthRisk GetByReadableId(HealthRiskReadableId readableId);
        Task<HealthRisk> GetByReadableIdAsync(HealthRiskReadableId readableId);

        HealthRiskId GetIdFromReadableId(HealthRiskReadableId readbleId);
        Task<HealthRiskId> GetIdFromReadableIdAsync(HealthRiskReadableId readbleId);


        void SaveHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
        Task SaveHealthRiskAsync(HealthRiskId id, HealthRiskReadableId readableId, string name);
        UpdateResult UpdateHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
        Task<UpdateResult> UpdateHealthRiskAsync(HealthRiskId id, HealthRiskReadableId readableId, string name);
    }
}
