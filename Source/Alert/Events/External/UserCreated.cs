using System;
using doLittle.Events;

namespace Events.External
{
    public class UserCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Geo { get; set; }
    }
}
