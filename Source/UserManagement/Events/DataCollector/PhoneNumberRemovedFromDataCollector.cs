using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.DataCollector
{
    public class PhoneNumberRemovedFromDataCollector : IEvent
    {
        public Guid DataCollectorId { get; }
        public string PhoneNumber { get; }

        public PhoneNumberRemovedFromDataCollector(Guid dataCollectorId, string phoneNumber)
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
        }
    }
}
