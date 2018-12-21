/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.ReadModels;

namespace Rules.Projects
{
    public class IsProjectNameUnique : IRuleImplementationFor<Domain.Projects.IsProjectNameUnique>
    {
        private readonly IReadModelRepositoryFor<Read.Projects.Project> _projects; 

        public IsProjectNameUnique(IReadModelRepositoryFor<Read.Projects.Project> projects)
        {
            _projects = projects; 
        }
        public Domain.Projects.IsProjectNameUnique Rule => name =>
        {
            return _projects.Query.Count(p => p.Name == name) == 0;
        };
    }
}