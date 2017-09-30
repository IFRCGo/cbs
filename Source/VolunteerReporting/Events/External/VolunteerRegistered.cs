using System;
using Infrastructure.Events;

namespace Events.External
{
    public class VolunteerRegistered : IEvent
    {    
        public Guid Id { get; set; }
    }
}