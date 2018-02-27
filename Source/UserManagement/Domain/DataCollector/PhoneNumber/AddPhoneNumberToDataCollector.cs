using System;
using doLittle.Commands;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}