using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class PhoneNumberRemovedFromDataCollector
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
