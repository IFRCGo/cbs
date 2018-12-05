using Domain.HealthRisks;
using Read.Projects;
using System;
using System.Linq;
using Dolittle.ReadModels;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskUniqueWithinProjectRule : IRuleImplementationFor<IsHealthRiskUniqueWithinProject>
    {
        private readonly IReadModelRepositoryFor<Project> _projects;
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskUniqueWithinProjectRule(IReadModelRepositoryFor<Project> projects, IReadModelRepositoryFor<HealthRisk> healthRisks)
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
