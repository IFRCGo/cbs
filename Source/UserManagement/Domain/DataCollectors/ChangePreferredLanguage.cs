using System;
using Concepts;
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class ChangePreferredLanguage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Language PreferredLanguage { get; set; }
    }
}