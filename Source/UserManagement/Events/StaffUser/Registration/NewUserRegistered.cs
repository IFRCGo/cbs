using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class NewUserRegistered : IEvent
    {
        public Guid StaffUserId { get;  }
        public string FullName { get;  }
        public string DisplayName { get; }
        public string Email { get; }   

        public DateTimeOffset RegisteredAt { get; }

        public NewUserRegistered(Guid staffUserId, string fullname, string displayName, string email, DateTimeOffset registeredAt)
        {
            StaffUserId = staffUserId;
            FullName = fullname;
            DisplayName = displayName;
            Email = email;
            RegisteredAt = registeredAt;
        }
    }
}