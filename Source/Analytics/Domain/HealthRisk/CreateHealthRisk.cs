using Dolittle.Commands;
using Concepts.HealthRisk;


namespace Domain.HealthRisk
{
    public class CreateHealthRisk : ICommand
    {
        public HealthRiskName HealthRiskName { get; set; }
        public HealthRiskGuid HealthRiskGuid { get; set; } 
    }
}
