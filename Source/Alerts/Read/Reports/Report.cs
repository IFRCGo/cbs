using System;
using Concepts.CaseReports;
using Dolittle.ReadModels;

namespace Read.Reports
{
    public class Report : IReadModel
    {
        public Report(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public Guid CaseReportId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public Sex Sex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int HealthRiskNumber { get; set; }
        public string OriginPhoneNumber { get; set; }
    }
}
