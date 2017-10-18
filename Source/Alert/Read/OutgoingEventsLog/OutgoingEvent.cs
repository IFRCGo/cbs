using System;

namespace Read
{
    public class OutgoingEvent : Entity
    {
        public string EventName { get; set; }
        public string Payload { get; set; }
    }
}
