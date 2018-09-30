using System;
using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class CreateHealthRisk : ICommand
    {
        public HealthRiskId Id {  get; set; }
        public HealthRiskName Name {  get; set; }
        public CaseDefinition CaseDefinition { get; set; }
        public HealthRiskNumber Number { get; set; }
    }
}