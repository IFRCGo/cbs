/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.Reporting.Projects;

namespace Read.Reporting.Projects
{
    public class ProjectsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<Project> _projects;

        public ProjectsEventProcessor(IReadModelRepositoryFor<Project> projects)
        {
            _projects = projects;
        }
        [EventProcessor("e6ce38f7-1db2-4238-b0a7-47036fe1a301")]
        public void Process(ProjectCreated @event)
        {
            var project = new Project
            {
                Id = @event.Id,
                Name = @event.Name
            };
            _projects.Insert(project);
        }
        [EventProcessor("56e5d632-608b-40e5-9197-9096046ce894")]
        public void Process(ProjectUpdated @event)
        {
            var project = _projects.GetById(@event.Id);
            project.Name = @event.Name;
            _projects.Update(project);
        }
    }
}