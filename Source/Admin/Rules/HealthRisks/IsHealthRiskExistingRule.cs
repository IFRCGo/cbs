using Domain.HealthRisks;
using System;
using Dolittle.ReadModels;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskExistingRule : IRuleImplementationFor<IsHealthRiskExisting>
    {
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskExistingRule(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public IsHealthRiskExisting Rule => (Guid healthRiskId) =>
        {
            return _healthRisks.GetById(healthRiskId) != null;
        };
    }
}
