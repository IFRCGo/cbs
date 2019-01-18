using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.Management.DataCollectors.Training
{
    public class EndTraining : ICommand
    {

        public DataCollectorId DataCollectorId { get; set; }
    }
}
