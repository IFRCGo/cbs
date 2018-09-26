using System;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class DeleteHealthRisk : ICommand
    {
        public Guid HealthRiskId { get; set; }   
    }
}