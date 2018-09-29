using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class SetCaseDefinition : ICommand
    {
        public HealthRiskId HealthRisk { get; set; }
        public CaseDefinition CaseDefinition { get; set; }
    }
}