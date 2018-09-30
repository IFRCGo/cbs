using Dolittle.Commands;
using System;

namespace Domain.DataCollectors
{
    public class DeleteDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
    }
}
