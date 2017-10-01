using System;
using System.Collections.Generic;
using System.Text;
using Events;
using Events.External;

namespace Read
{
    public class ProjectRoleEventProcessor : Infrastructure.Events.IEventProcessor
    {
        private readonly IProjectRoles _projectRoles;

        public ProjectRoleEventProcessor(IProjectRoles roles)
        {
            _projectRoles = roles;
        }

        public void Process(ProjectRoleCreated @event)
        {
            ProjectRole user = new ProjectRole()
            {
                Id = @event.Id,
                Name = @event.Name,
                ParentRoleId = @event.ParentRoleId,
                ProjectId = @event.ProjectId,
                UserId = @event.UserId
            };
           _projectRoles.Save(user);
        }
    }
}
