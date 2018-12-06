/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

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
