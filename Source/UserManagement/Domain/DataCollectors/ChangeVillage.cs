using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class ChangeVillage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}