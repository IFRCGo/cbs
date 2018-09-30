using Domain.HealthRisks;
using Domain.Projects;
using Infrastructure.Read.MongoDb;
using Infrastructure.Rules;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Text;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskExistingRule : IRuleImplementationFor<IsHealthRiskExisting>
    {
        private readonly IExtendedReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskExistingRule(IExtendedReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public IsHealthRiskExisting Rule => (Guid healthRiskId) =>
        {
            return _healthRisks.GetById(healthRiskId) != null;
        };
    }
}
