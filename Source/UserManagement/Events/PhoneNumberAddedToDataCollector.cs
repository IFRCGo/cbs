using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class PhoneNumberAddedToDataCollector
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
