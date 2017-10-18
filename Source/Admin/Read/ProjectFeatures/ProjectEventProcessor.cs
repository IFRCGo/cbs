/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events;
using Infrastructure.Events;

namespace Read.ProjectFeatures
{
    public class ProjectEventProcessor : IEventProcessor
    {
        readonly IProjects _projects;

        public ProjectEventProcessor(IProjects projects)
        {
            _projects = projects;
        }

        public void Process(ProjectCreated @event)
        {
            var project = _projects.GetById(@event.Id);
            project.Name = @event.Name;
            _projects.Save(project);
        }
    }
}