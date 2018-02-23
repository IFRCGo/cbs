using System;
using doLittle.Events;

namespace Events
{
    public class StaffUserDeleted : IEvent
    {
        public Guid Id { get; set; }
        //TODO: Good idea for knowing which kind of User it is and so that we don't need
        // a Deleted-event for each kind of StaffUser role?
        public int Role { get; set; } 
    }
}