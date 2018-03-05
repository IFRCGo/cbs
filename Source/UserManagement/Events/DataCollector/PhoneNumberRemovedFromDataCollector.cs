using doLittle.Events;
using System;
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
