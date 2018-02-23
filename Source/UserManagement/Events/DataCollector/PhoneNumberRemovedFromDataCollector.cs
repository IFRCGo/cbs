using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.DataCollector
{
    public class PhoneNumberRemovedFromDataCollector : IEvent
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
