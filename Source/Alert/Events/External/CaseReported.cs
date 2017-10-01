using System;
using Infrastructure.Events;

namespace Events.External
{
    public class CaseReported : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public DateTime CaseOccured { get; set; }
        public string Location { get; set; }
        public Guid DataCollectorId { get; set; }
    }
}
