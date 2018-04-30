using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class BaseUserInformationChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}