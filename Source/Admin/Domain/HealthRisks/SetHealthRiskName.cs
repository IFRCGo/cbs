using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class SetHealthRiskName : ICommand
    {
        public HealthRiskId HealthRisk { get; set; }
    }
}