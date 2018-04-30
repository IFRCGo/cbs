using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class SystemConfiguratorNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }

    public class DataCoordinatorNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }

    public class DataOwnerNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }

    public class DataVerifierNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }
}