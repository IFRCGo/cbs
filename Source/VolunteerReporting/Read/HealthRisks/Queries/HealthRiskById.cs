using System;
using System.Linq;
using Concepts;
using Dolittle.Queries;

namespace Read.HealthRisks.Queries
{
    public class HealthRiskById : IQueryFor<HealthRisk>
    {
        private readonly IHealthRisks _collection;

        public HealthRiskId HealthRiskId { get; set; }

        public HealthRiskById(IHealthRisks collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query.Where(h => h.Id == HealthRiskId);
    }
}