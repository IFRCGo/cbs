using System;
using Dolittle.Events;

namespace Events.HealthRisk
{
    public class ThresholdAddedToHealthRIsk : IEvent
    {
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; }

        public ThresholdAddedToHealthRIsk(Guid healthRiskId, int threshold)
        {
            HealthRiskId = healthRiskId;
            Threshold = threshold;
        }
    }
}