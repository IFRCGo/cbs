/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Read.Projects;
using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;

namespace Rules.HealthRisks
{
    public class IsHealthRiskUniqueWithinProject : IRuleImplementationFor<Domain.HealthRisks.IsHealthRiskUniqueWithinProject>
    {
        private readonly IReadModelRepositoryFor<Project> _projects;

        public IsHealthRiskUniqueWithinProject(IReadModelRepositoryFor<Project> projects)
        {
            _projects = projects;
        }

        public Domain.HealthRisks.IsHealthRiskUniqueWithinProject Rule => (healthRiskId, projectId) =>
        {
            var project = _projects.GetById(projectId);
            return project.HealthRisks?.All(p => p.HealthRiskId != healthRiskId) ?? true;
        };
    }
}
