using System;
using Concepts;
using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangePreferredLanguage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Language PreferredLanguage { get; set; }
    }
}