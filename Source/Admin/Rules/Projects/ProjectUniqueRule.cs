/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Domain.Projects;

namespace Rules.Projects
{
    public class ProjectUniqueRule : IRuleImplementationFor<ProjectNameUnique>
    {
        private readonly IReadModelRepositoryFor<Read.Projects.Project> _projects; 

        public ProjectUniqueRule(IReadModelRepositoryFor<Read.Projects.Project> projects)
        {
            _projects = projects; 
        }

        public ProjectNameUnique Rule => (string name) => throw new NotImplementedException();
    }
}