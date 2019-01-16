using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.Management.DataCollectors.Registration
{
    public class DeleteDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
