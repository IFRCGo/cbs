
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumberFromDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}