using Dolittle.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollector
{
    public class DeleteDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
    }
}
