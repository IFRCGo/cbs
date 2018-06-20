using System;
using Concepts;
using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangeLocation : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Location Location { get; set; }
    }
}