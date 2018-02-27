using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportFromUnknownDataCollector
    {
        public Guid Id { get; set; }
        public string Origin { get; internal set; }
        public Guid HealthRiskId { get; internal set; }
        public int NumberOfFemalesAgedOver4 { get; internal set; }
        public int NumberOfFemalesAges0To4 { get; internal set; }
        public int NumberOfMalesAgedOver4 { get; internal set; }
        public int NumberOfMalesAges0To4 { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }

        public CaseReportFromUnknownDataCollector(Guid id)
        {
            this.Id = id;
        }

    }
}