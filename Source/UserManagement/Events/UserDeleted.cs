using System;
using doLittle.Events;

namespace Events
{
    public class UserDeleted : IEvent
    {
        public Guid Id { get; set; }
    }
}