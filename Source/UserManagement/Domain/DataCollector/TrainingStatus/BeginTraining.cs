using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollector.TrainingStatus
{
    public class BeginTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
