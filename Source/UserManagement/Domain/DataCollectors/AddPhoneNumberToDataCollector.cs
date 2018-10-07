using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberToDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}