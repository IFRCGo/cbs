using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class NationalSocietyAssignedToSystemConfigurator : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }

    public class NationalSocietyAssignedToDataCoordinator : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }
    }
}