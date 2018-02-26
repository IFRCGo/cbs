using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class AdminUpdated : IEvent
    {
        public Guid StaffUserId { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }

        public AdminUpdated(Guid staffUserId, string fullName, string displayName, string email)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
        }
    }
}