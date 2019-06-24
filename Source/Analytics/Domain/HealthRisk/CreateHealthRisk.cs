using Dolittle.Commands;
using Concepts.HealthRisk;


namespace Domain.HealthRisk
{
    public class CreateHealthRisk : ICommand
    {
        public HealthRiskName HealthRiskName { get; set; }
        public HealthRiskId HealthRiskId { get; set; } 
        public HealthRiskNumber HealthRiskNumber { get; set; }
    }
}
