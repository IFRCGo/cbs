using Concepts;
using Dolittle.Commands;

namespace Domain.AlertRules
{
    public class CreateAlertRule : ICommand
    {
        public RuleId Id { get; set; }
        public AlertRuleName AlertRuleName { get; set; }
        public NumberOfCasesThreshold NumberOfCasesThreshold { get; set; }
        public ThresholdTimeframe ThresholdTimeframe { get; set; }
        public HealthRiskId HealthRiskId { get; set; }
        public DistanceBetweenCasesInMeters DistanceBetweenCasesInMeters { get; set; }
        
    }
}
