using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollector.TrainingStatus
{
    public class EndTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
