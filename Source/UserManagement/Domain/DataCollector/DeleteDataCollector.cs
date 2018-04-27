using Dolittle.Commands;
using System;

namespace Domain.DataCollector
{
    public class DeleteDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
    }
}
