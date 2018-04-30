using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class SystemConfiguratorPreferredLanguageChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int Language { get; set; }
    }

    public class DataCoordinatorPreferredLanguageChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int Language { get; set; }
    }

    public class DataOwnerPreferredLanguageChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int Language { get; set; }
    }

    public class DataVerifierPreferredLanguageChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int Language { get; set; }
    }
}