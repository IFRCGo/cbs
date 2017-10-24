using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReport
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; internal set; }
        public Guid HealthRiskId { get; internal set; }
        public int NumberOfFemalesOver5 { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; }
        public int NumberOfMalesOver5 { get; internal set; }
        public int NumberOfMalesUnder5 { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

        public CaseReport(Guid id)
        {
            this.Id = id;
        }

    }
}