using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollectors.Changing
{
    public class ChangeVillage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}