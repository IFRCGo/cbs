using System;
using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollector.DataVerifier
{
    public class ChangeDataVerifier : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Guid DataVerifierId { get; set; }
    }
}
