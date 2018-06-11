using System;
using Concepts;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangeVillage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}