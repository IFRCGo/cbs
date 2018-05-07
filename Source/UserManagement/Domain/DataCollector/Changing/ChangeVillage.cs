using System;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangeVillage : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string Village { get; set; }


    }
}