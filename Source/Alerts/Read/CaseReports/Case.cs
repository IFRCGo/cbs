using System;
using Concepts.CaseReports;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class Case : IReadModel
    {
        public Case(Guid id)
        {
            CaseId = id;
        }

        public Guid CaseId { get; }
        public Guid CaseReportId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public Sex Sex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int HealthRiskNumber { get; set; }
    }
}
