using doLittle.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumber : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
