using Dolittle.Commands;
using Concepts;


namespace Domain.HealthRisk
{
    public class CreateHealthRisk : ICommand
    {
        public HealthRiskName HealthRiskName { get; set; }
        public HealthRiskGuid HealthRiskGuid { get; set; } 
    }
}
