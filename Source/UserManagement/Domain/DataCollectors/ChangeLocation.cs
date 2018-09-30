using System;
using Concepts;
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class ChangeLocation : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Location Location { get; set; }
    }
}