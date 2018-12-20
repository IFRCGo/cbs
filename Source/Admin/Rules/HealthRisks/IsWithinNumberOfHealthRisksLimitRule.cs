/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.HealthRisks;
using Read.Projects;
using Dolittle.ReadModels;

namespace Rules.HealthRisks
{
    public class IsWithinNumberOfHealthRisksLimitRule : IRuleImplementationFor<IsWithinNumberOfHealthRisksLimit>
    {
        private readonly IReadModelRepositoryFor<Project> _projects;
        private const int MaxNumberOfHealthRisksForProject = 5;

        public IsWithinNumberOfHealthRisksLimitRule(IReadModelRepositoryFor<Project> projects)
        {
            _projects = projects;
        }

        public IsWithinNumberOfHealthRisksLimit Rule => projectId =>
        {
            var project = _projects.GetById(projectId);
            var numberOfRisks = project.HealthRisks?.Length ?? 0;

            return numberOfRisks < MaxNumberOfHealthRisksForProject;
        }; 
    }
}