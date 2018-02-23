using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events.StaffUser
{
    public class AdminAdded : IEvent
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }

        public AdminAdded(Guid id, string fullName, string displayName, string email)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
        }
    }

}

