using doLittle.Commands;
using System;

namespace Domain.DataCollectors
{
    public class AddPhoneNumber : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
