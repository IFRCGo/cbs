using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.Management.DataCollectors.Training
{
    public class BeginTraining : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
    }
}
