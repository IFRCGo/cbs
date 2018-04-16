using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReport
    {
        public Guid Id { get; private set; }
        public Guid DataCollectorId { get; internal set; }
        public Guid HealthRiskId { get; internal set; }
        public int NumberOfFemalesAged5AndOlder { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; }
        public int NumberOfMalesAged5AndOlder { get; internal set; }
        public int NumberOfMalesUnder5 { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

        public CaseReport(Guid id)
        {
            this.Id = id;
        }

    }
}