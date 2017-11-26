using System;

namespace Events.External
{
    public class ProjectDataCollectorPositionChanged
    {
        public Guid Userid { get; set; }
        private LongLat Position { get; set; }
    }
}