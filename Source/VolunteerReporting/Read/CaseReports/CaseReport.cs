using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReport : IReadModel
    {
        public CaseReportId Id { get; set; }

        public string Message { get; set; }
        public DataCollectorId DataCollectorId { get; set ; }
        public HealthRiskId HealthRiskId { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Location Location { get; set; }

        public CaseReport(CaseReportId id)
        {
            Id = id;
        }
    }
}