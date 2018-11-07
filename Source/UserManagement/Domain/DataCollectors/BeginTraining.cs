using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class BeginTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
