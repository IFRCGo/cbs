using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class DataOwnerInformationChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string DutyStation { get; set; }
        public string Position { get; set; }
    }
}