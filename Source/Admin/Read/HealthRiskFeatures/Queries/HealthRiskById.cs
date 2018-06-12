using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.HealthRiskFeatures.Queries
{
    public class HealthRiskById : IQueryFor<HealthRisk>
    {
        readonly IHealthRisks _collection;
        public Guid HealthRiskId { get; set; }

        public HealthRiskById(IHealthRisks collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query.Where(h => h.Id == HealthRiskId);
    }
}