/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.Projects;
using Read.Projects;
using System;
using System.Linq;
using Dolittle.ReadModels;

namespace Rules.Projects
{
    public class IsUserNotAVerifierRule : IRuleImplementationFor<IsUserNotAVerifier>
    {
        private readonly IReadModelRepositoryFor<Project> _projects; 

        public IsUserNotAVerifierRule(IReadModelRepositoryFor <Project> projects)
        {
            _projects = projects; 
        }

        public IsUserNotAVerifier Rule => (Guid projectId, Guid userId) =>
        {
            return _projects.GetById(projectId).DataVerifiers.All(v => v.Id != userId);
        }; 
    }
}