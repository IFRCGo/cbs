using Concepts.Report;
using Dolittle.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.Reports.AvailableForRules
{
    public class AvailableReport : IReadModel
    {
        public ReportId Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid HealthRiskId { get; set; }
        public int HealthRiskNumber { get; set; }
    }
}
