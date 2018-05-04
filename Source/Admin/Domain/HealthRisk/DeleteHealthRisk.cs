using System;
using Dolittle.Commands;

namespace Domain.HealthRisk
{
    public class DeleteHealthRisk : ICommand
    {
        public Guid HealthRiskId { get; set; }   
    }
}