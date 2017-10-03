using System;
using Infrastructure.Events;

namespace Events
{
    public class CaseReportReceived : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }        
        public Guid DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}