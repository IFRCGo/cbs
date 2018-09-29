using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class HealthRiskById : IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repository;

        public HealthRiskById(IReadModelRepositoryFor<HealthRisk> repository)
        {
            _repository = repository;
        }

        public Guid HealthRiskId { get; set; }

        public IQueryable<HealthRisk> Query => _repository.Query.Where(h => h.Id == HealthRiskId);
    }
}