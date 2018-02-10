using System;
using doLittle.Events;

namespace Events
{
    public class ProjectHealthRiskAdded : IEvent
    {
        public Guid ProjectId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; }
    }
}