using System;
using doLittle.Commands;

namespace Domain.DataCollectors.Commands
{
    public class AddPhoneNumberToDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}