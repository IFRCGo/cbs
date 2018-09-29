/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.Projects;
using Infrastructure.Rules;
using Read.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.RuleImplementations.Projects
{
    public class IsUserNotAVerifierRule : IRuleImplementationFor<IsUserNotAVerifier>
    {
        private readonly IProjects _projects; 

        public IsUserNotAVerifierRule(IProjects projects)
        {
            _projects = projects; 
        }

        public IsUserNotAVerifier Rule => (Guid projectId, Guid userId) =>
        {
            return _projects.GetById(projectId).DataVerifiers.All(v => v.Id != userId);
        }; 
    }
}
