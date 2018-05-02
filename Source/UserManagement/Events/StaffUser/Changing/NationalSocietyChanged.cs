using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class SystemConfiguratorNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }

        public SystemConfiguratorNationalSocietyChanged(Guid staffUserId, Guid nationalSociety)
        {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
    }

    public class DataCoordinatorNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }

        public DataCoordinatorNationalSocietyChanged(Guid staffUserId, Guid nationalSociety)
        {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
    }

    public class DataOwnerNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }

        public DataOwnerNationalSocietyChanged(Guid staffUserId, Guid nationalSociety)
        {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
    }

    public class DataVerifierNationalSocietyChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }

        public DataVerifierNationalSocietyChanged(Guid staffUserId, Guid nationalSociety)
        {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
    }
}