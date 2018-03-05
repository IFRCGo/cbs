using System;
using Concepts;
using doLittle.Events;

namespace Events
{
    public class MessageGenerated : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
