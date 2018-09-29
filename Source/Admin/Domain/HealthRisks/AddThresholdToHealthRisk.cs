using System;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class AddThresholdToHealthRisk : ICommand
    {
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; }
    }
}