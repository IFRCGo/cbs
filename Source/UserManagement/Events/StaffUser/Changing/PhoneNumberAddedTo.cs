using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class PhoneNumberAddedToSystemConfigurator : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PhoneNumberAddedToDataCoordinator : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PhoneNumberAddedToDataOwner : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PhoneNumberAddedToDataVerifier : IEvent
    {
        public Guid StaffUserId { get; set; }
        public string PhoneNumber { get; set; }
    }
}