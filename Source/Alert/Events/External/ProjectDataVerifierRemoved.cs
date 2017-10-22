using System;

namespace Events.External
{
    public class ProjectDataVerifierRemoved
    {
        public Guid ProjectId { get; set; }

        public Guid Userid { get; set; }
    }
}