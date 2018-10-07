using Domain.HealthRisks;
using Infrastructure.Read.MongoDb;
using Infrastructure.Rules;
using Read.HealthRisks;
using Read.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskUniqueWithinProjectRule : IRuleImplementationFor<IsHealthRiskUniqueWithinProject>
    {
        private readonly IProjects _projects;
        private readonly IExtendedReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskUniqueWithinProjectRule(IProjects projects, IExtendedReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _projects = projects;
            _healthRisks = healthRisks;
        }

        public IsHealthRiskUniqueWithinProject Rule => (Guid healthRiskId, Guid projectId) =>
        {
            var project = _projects.GetById(projectId);
            return project.HealthRisks?.All(p => p.HealthRiskId != healthRiskId) ?? true;
        };
    }
}
