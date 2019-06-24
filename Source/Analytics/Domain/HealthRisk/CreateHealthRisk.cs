using Dolittle.Commands;
using Concepts.HealthRisk;


namespace Domain.HealthRisk
{
    public class CreateHealthRisk : ICommand
    {
        public HealthRiskId HealthRiskId = new HealthRiskId();
        public HealthRiskName HealthRiskName { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
    }
}
