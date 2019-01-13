using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Projects
{
    public class ProjectCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<Project> _aggregate;

        public ProjectCommandHandler(IAggregateRootRepositoryFor<Project> aggregate)
        {
            _aggregate = aggregate;
        }

        public void Handle(CreateProject cmd)
        {
            var root = _aggregate.Get(cmd.Id.Value);
            root.CreateProject(cmd.Name, cmd.NationalSocietyId, cmd.DataOwnerId, cmd.SurveillanceContext);
        }

        public void Handle(UpdateProject cmd)
        {

        }
        
        public void Handle(UpdateProjectHealthRiskThreshold cmd)
        {

        }        
    }
}
