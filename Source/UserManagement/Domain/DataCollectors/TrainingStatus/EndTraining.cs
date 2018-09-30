using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollectors.TrainingStatus
{
    public class EndTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
