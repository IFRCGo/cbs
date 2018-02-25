using System;
using Concepts;
using doLittle.Events;

namespace Events
{
    public class MessageGenerated : IEvent
    {
        public Guid Id { get; set; } //QUESTION: einari, michael: What does this represent? An EventSourceId or the StaffUserId of the datacollector?
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
