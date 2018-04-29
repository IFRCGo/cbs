using Dolittle.Events;
using System;
using System.Collections.Generic;

namespace Events.DataCollector
{
    public class PhoneNumberRemovedFromDataCollector : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneNumberRemovedFromDataCollector(Guid dataCollectorId, string phoneNumber)
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
        }
    }
}
