using System;
using Dolittle.Events;

namespace Events.StaffUser
{
    public class StaffUserDeleted : IEvent
    {
        public Guid StaffUserId { get; set; }

        public StaffUserDeleted(Guid staffUserId)
        {
            StaffUserId = staffUserId;
        }
    }
}