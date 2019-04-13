using System;
using Concepts.Alerts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.Alerts
{
    public class AlertOverview : IReadModel
    {
        public AlertNumber AlertNumber { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
        public string HealthRiskName { get; set; }
        public int NumberOfReports { get; set; }
        public DateTime OpenedAt { get; set; }
        public AlertStatus Status { get; set; }
    }
}
