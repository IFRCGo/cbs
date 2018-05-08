using Dolittle.Events.Processing;
using Events.External;
namespace Read.Projects
{
    public class ProjectsEventProcessor : ICanProcessEvents
    {
        private readonly IProjects _projects;

        public ProjectsEventProcessor(IProjects projects)
        {
            _projects = projects;
        }
        public void Process(ProjectCreated @event)
        {
            _projects.SaveProject(@event.Id, @event.Name);
        }

        public void Process(ProjectUpdated @event)
        {
            _projects.UpdateProject(@event.Id, @event.Name);
        }
    }
}
