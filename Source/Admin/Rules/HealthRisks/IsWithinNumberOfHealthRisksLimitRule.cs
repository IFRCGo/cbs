/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.HealthRisks;
using Read.Projects;
using System;
using Dolittle.ReadModels;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsWithinNumberOfHealthRisksLimitRule : IRuleImplementationFor<IsWithinNumberOfHealthRisksLimit>
    {
        private readonly IReadModelRepositoryFor<Project> _projects;
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;
        private const int MaxNumberOfHealthRisksForProject = 5;

        public IsWithinNumberOfHealthRisksLimitRule(IReadModelRepositoryFor<Project> projects, IReadModelRepositoryFor<HealthRisk> healthRisks)
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