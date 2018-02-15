using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportFromUnknownDataCollector
    {
        public Guid Id { get; set; }
        public string Origin { get; internal set; }
        public Guid HealthRiskId { get; internal set; }
        public int NumberOfFemalesOver5 { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; }
        public int NumberOfMalesOver5 { get; internal set; }
        public int NumberOfMalesUnder5 { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }

        public CaseReportFromUnknownDataCollector(Guid id)
        {
            this.Id = id;
        }

    }
}