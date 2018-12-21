/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Dolittle.ReadModels;

namespace Rules.Projects
{
    public class IsUserNotAVerifierRule : IRuleImplementationFor<Domain.Projects.Rules>
    {
        private readonly IReadModelRepositoryFor<Read.Projects.Project> _projects; 

        public IsUserNotAVerifierRule(IReadModelRepositoryFor <Read.Projects.Project> projects)
        {
            _projects = projects; 
        }

        public Domain.Projects.Rules Rule => (Guid projectId, Guid userId) =>
        {
            return _projects.GetById(projectId).DataVerifiers.All(v => v.Id != userId);
        }; 
    }
}