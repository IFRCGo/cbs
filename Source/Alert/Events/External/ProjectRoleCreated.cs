using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectRoleCreated
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        public Guid? ParentRoleId { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
