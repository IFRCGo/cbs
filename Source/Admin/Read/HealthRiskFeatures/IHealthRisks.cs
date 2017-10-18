using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.HealthRiskFeatures
{
    public interface IHealthRisks
    {
        void Save(HealthRisk project);

        IEnumerable<HealthRisk> GetAll();

        Task<IEnumerable<HealthRisk>> GetAllAsync();
    }
}
