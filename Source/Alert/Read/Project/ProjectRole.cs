using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class ProjectRole : Entity
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }
        public Guid? ParentRoleId { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
