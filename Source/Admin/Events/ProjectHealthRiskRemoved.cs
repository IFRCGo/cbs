using System;
using doLittle.Events;

namespace Events
{
    public class ProjectHealthRiskRemoved : IEvent
    {
        public Guid ProjectId { get; set; }
        public Guid HealthRiskId { get; set; }
    }
}