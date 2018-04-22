using System;
using Dolittle.Commands;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}