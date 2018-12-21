using Concepts.NationalSocieties;
using Concepts.Projects;
using Concepts.Users;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Projects;

namespace Domain.Projects
{
    public class Project : AggregateRoot
    {
        public Project(EventSourceId id) : base(id)
        {             
        }

        public void CreateProject(ProjectName name, NationalSocietyId nationalSocietyId, UserId dataOwnerId, int surveillanceContext)
        {
            Apply(new ProjectCreated(EventSourceId, name, nationalSocietyId, dataOwnerId, (int) surveillanceContext));
        }
    }
}