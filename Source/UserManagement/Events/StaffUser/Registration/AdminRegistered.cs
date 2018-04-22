using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class AdminRegistered : IEvent
    {
        public AdminRegistered(Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registeredAt)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegisteredAt = registeredAt;
        }

        public Guid StaffUserId { get; }

        public string FullName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public DateTimeOffset RegisteredAt { get; }
    }
}