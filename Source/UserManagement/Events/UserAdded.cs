using System;
using Infrastructure.Events;

namespace Events
{
    public class UserAdded : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
