using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class OverrideHealthRiskName : ICommand
    {
        public HealthRiskId HealthRisk { get; set; }
        public HealthRiskName Name { get; set; }
    }
}