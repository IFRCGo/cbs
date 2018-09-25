using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("52a974ab-383c-4750-b788-528f43b7ebf8")]
    public class HealthRiskDeleted : IEvent
    {
        public HealthRiskDeleted(Guid healthRiskId) 
        {
            this.HealthRiskId = healthRiskId;
               
        }
        public Guid HealthRiskId { get; }
    }
}