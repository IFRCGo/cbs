using Dolittle.Events;

namespace Events
{
    public class HealthRiskCreated : IEvent
    {
        public HealthRiskCreated(Guid eventSourceId, string healthRiskName)
        {
            HealthRiskId = eventSourceId;
            HealthRiskName = healthRiskName;
        }

        public EventSourceId HealthRiskId { get; }
        public string HealthRiskName { get; }

    }
}
