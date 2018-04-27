using System;
using Concepts;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangePreferredLanguage : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public Language PreferredLanguage { get; set; }
    }
}