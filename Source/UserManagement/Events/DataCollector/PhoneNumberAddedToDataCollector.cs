using Dolittle.Events;
using System;

namespace Events.DataCollector
{
    public class PhoneNumberAddedToDataCollector : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneNumberAddedToDataCollector(Guid dataCollectorId, string phoneNumber)
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
        }
    }
}
