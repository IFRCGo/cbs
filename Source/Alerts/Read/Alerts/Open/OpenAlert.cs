using Concepts.Alerts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.Alerts.Open
{
    public class OpenAlert : IReadModel
    {
        public HealthRiskNumber Id { get; set; }
        public AlertId AlertId { get; set; }
        public AlertNumber AlertNumber { get; set; }               
    }
}
