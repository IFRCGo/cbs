using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class ThresholdAddedToHealthRIsk : IEvent
    {

        public ThresholdAddedToHealthRIsk(Guid healthRiskId, int threshold)
        {
            HealthRiskId = healthRiskId;
            Threshold = threshold;
        }
        public Guid HealthRiskId { get; }
        public int Threshold { get; }
    }
}