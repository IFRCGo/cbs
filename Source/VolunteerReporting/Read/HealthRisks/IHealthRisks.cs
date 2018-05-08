using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.HealthRisks
{
    public interface IHealthRisks : IGenericReadModelRepositoryFor<HealthRisk, Guid>
    {
        IEnumerable<HealthRisk> GetAll();
        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(Guid id);
        Task<HealthRisk> GetByIdAsync(Guid id);

        HealthRisk GetByReadableId(int readableId);
        Task<HealthRisk> GetByReadableIdAsync(int readableId);

        HealthRiskId GetIdFromReadableId(int readbleId);
        Task<HealthRiskId> GetIdFromReadableIdAsync(int readbleId);


        void SaveHealthRisk(Guid id, int readableId, string name);
        Task SaveHealthRiskAsync(Guid id, int readableId, string name);
        UpdateResult UpdateHealthRisk(Guid id, int readableId, string name);
        Task<UpdateResult> UpdateHealthRiskAsync(Guid id, int readableId, string name);
    }
}
