using Dolittle.Events.Processing;
using Events.Admin.Projects;

namespace Read.Projects
{
    public class ProjectsEventProcessor : ICanProcessEvents
    {
        private readonly IProjects _projects;

        public ProjectsEventProcessor(IProjects projects)
        {
            _projects = projects;
        }
        [EventProcessor("e6ce38f7-1db2-4238-b0a7-47036fe1a301")]
        public void Process(ProjectCreated @event)
        {
            _projects.SaveProject(@event.Id, @event.Name);
        }
        [EventProcessor("56e5d632-608b-40e5-9197-9096046ce894")]
        public void Process(ProjectUpdated @event)
        {
            _projects.UpdateProject(@event.Id, @event.Name);
        }
    }
}
