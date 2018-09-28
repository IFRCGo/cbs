using Concepts.DataCollector;
using Concepts.DataVerifier;
using Dolittle.Commands;

namespace Domain.DataCollector.DataVerifier
{
    public class ChangeDataVerifier : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public DataVerifierId DataVerifierId { get; set; }
    }
}
