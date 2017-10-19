using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectRoleCreated
    {
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        public Guid? ParentRoleId { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
