using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class StaffUserDeleted : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int Role { get; set; } 
    }
}