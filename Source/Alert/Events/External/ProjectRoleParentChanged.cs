using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectRoleParentChanged
    {
        public Guid Id { get; set; }

        public Guid? ParentRoleId { get; set; }
    }
}
