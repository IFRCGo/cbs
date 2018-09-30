/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Infrastructure.Rules;
using Read.Projects;
using System;
using System.Linq; 
using System.Collections.Generic;
using System.Text;
using Domain.Projects;

namespace Rules.Projects
{
    public class ProjectUniqueRule : IRuleImplementationFor<ProjectNameUnique>
    {
        private readonly IProjects _projects; 

        public ProjectUniqueRule(IProjects projects)
        {
            _projects = projects; 
        }

        public ProjectNameUnique Rule => (string name) =>
        {
            return _projects.GetAll().All(p => !p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        };
    }
}
