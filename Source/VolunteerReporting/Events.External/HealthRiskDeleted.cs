using System;
using Dolittle.Events;

namespace Events.External
{
    public class HealthRiskDeleted : IEvent
    {
        public Guid HealthRiskId { get; set; }
    }
}