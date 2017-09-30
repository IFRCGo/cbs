using System;
using Infrastructure.Events;

namespace Events
{
    public class VolunteerUserAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}