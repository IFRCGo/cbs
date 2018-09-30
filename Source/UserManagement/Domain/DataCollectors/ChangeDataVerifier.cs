using System;
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class ChangeDataVerifier : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Guid DataVerifierId { get; set; }
    }
}
