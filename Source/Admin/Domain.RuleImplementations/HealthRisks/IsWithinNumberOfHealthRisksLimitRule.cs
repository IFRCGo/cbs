using Domain.HealthRisks;
using Domain.Projects;
using Infrastructure.Read.MongoDb;
using Infrastructure.Rules;
using Read.HealthRisks;
using Read.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Domain.RuleImplementations.HealthRisks
{
    public class IsWithinNumberOfHealthRisksLimitRule : IRuleImplementationFor<IsWithinNumberOfHealthRisksLimit>
    {
        private readonly IProjects _projects;
        private readonly IExtendedReadModelRepositoryFor<HealthRisk> _healthRisks;
        private const int MaxNumberOfHealthRisksForProject = 5;

        public IsWithinNumberOfHealthRisksLimitRule(IProjects projects, IExtendedReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _projects = projects;
            _healthRisks = healthRisks;
        }

        public IsWithinNumberOfHealthRisksLimit Rule => (Guid projectId) =>
        {
            var project = _projects.GetById(projectId);
            var numberOfRisks = project.HealthRisks?.Length ?? 0;

            return numberOfRisks < MaxNumberOfHealthRisksForProject;
        }; 
    }
}
