using System;

namespace Events.External
{
    public class ProjectDataCollectorRemoved
    {
        public Guid ProjectId { get; set; }
        public Guid DataVerifierId { get; set; }
        public Guid Userid { get; set; }
    }
}