using System;

namespace Events.External
{
    public class ProjectDataCollectorAdded
    {
        public Guid ProjectId { get; set; }
        public Guid Userid { get; set; }
        public Guid DataVerifierId { get; set; }
        public LongLat Location { get; set; }
    }
}