using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.HealthRisks
{
    public interface IHealthRisks : IGenericReadModelRepositoryFor<HealthRisk, Guid>
    {
        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(Guid id);

        HealthRisk GetByReadableId(int readableId);

        HealthRiskId GetIdFromReadableId(int readbleId);
        

    }
}
