using Concepts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.HealthRisks
{
    public interface IHealthRisks
    {
        Task<IEnumerable<HealthRisk>> GetAllAsync();
        HealthRisk GetById(Guid id);
        HealthRisk GetByReadableId(int readableId);
        HealthRiskId GetIdFromReadableId(int readbleId);
        void Save(HealthRisk dataCollector);
        void Remove(Guid healthRiskId);
        Task SaveAsync(HealthRisk dataCollector);
        Task RemoveAsync(Guid healthRiskId);

        UpdateResult Update(FilterDefinition<HealthRisk> filter, UpdateDefinition<HealthRisk> update);
        Task<UpdateResult> UpdateAsync(FilterDefinition<HealthRisk> filter, UpdateDefinition<HealthRisk> update);

        void Remove(FilterDefinition<HealthRisk> filter);
        void Remove(Expression<Func<HealthRisk, bool>> filter);

        Task RemoveAsync(FilterDefinition<HealthRisk> filter);
        Task RemoveAsync(Expression<Func<HealthRisk, bool>> filter);

    }
}
