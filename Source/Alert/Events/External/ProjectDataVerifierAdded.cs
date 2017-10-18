using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectDataVerifierAdded
    {
        public Guid ProjectId { get; set; }

        public Guid Userid { get; set; }
    }
}
