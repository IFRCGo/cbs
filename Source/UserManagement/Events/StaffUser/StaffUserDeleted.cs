using System;
using Dolittle.Events;

namespace Events.StaffUser
{
    public class StaffUserDeleted : IEvent
    {
        public Guid StaffUserId { get; }

        public StaffUserDeleted(Guid staffUserId)
        {
            StaffUserId = staffUserId;
        }
    }
}