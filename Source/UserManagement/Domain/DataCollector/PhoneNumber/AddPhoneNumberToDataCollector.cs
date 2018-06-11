using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.Commands;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}