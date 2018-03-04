using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class NewUserRegistered : IEvent 
    {
        public NewUserRegistered (Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registeredAt) 
        {
            this.StaffUserId = staffUserId;
            this.FullName = fullName;
            this.DisplayName = displayName;
            this.Email = email;
            this.RegisteredAt = registeredAt;
        }
        public Guid StaffUserId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public DateTimeOffset RegisteredAt { get; }
    }
}