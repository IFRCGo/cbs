using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReport
    {
        public Guid Id { get; private set; }
        public Guid DataCollectorId { get; internal set; }
        public Guid HealthRiskId { get; internal set; }
        public int NumberOfFemalesAgedOver4 { get; internal set; }
        public int NumberOfFemalesAges0To4 { get; internal set; }
        public int NumberOfMalesAgedOver4 { get; internal set; }
        public int NumberOfMalesAges0To4 { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

        public CaseReport(Guid id)
        {
            this.Id = id;
        }

    }
}