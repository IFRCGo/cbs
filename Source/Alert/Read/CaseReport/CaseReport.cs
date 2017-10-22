using System;

namespace Read
{
    public class CaseReport : Entity
    {
        public Guid DataCollectorId { get; set; }
        public DateTime SubmissionTimestamp { get; set; }
        public Guid HealthRiskId { get; set; }
        public string Location { get; set; }
    }
}
