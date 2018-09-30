using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class EndTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
