using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollectors.TrainingStatus
{
    public class BeginTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
