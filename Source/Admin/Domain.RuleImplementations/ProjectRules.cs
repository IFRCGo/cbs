/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Read.ProjectFeatures;

namespace Domain.RuleImplementations
{
    public class ProjectRules : IProjectRules
    {
        private readonly IProjects _projects;

        public ProjectRules(IProjects projects)
        {
            _projects = projects;
        }
        public bool IsProjectNameUnique(string name)
        {
            return _projects.GetAll().All(p => !p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool IsUserNotAVerifier(Guid projectId, Guid userId)
        {
            return _projects.GetById(projectId).DataVerifiers.All(v => v.Id != userId);
        }
    }
}