using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.DataCollector
{
    public class PhoneNumberAddedToDataCollector : IEvent
    {
        // QUESTION: Needed? Is this EventSourceId? If so, then all events should have this? public Guid Id { get; set; }
        public Guid DataCollectorId { get; private set; }
        public string PhoneNumber { get; private set; }

        public PhoneNumberAddedToDataCollector(Guid dataCollectorId, string phoneNumber)
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
        }
    }
}
