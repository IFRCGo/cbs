using System;

namespace Events.External
{
    public class ProjectDataVerifierChanged
    {
        public Guid ProjectId { get; set; }
        public Guid Userid { get; set; }
    }
}