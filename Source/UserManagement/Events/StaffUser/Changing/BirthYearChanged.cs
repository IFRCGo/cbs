using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class SystemConfiguratorBirthYearChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int BirthYear { get; set; }
    }
    public class DataCoordinatorBirthYearChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int BirthYear { get; set; }
    }
    public class DataOwnerBirthYearChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int BirthYear { get; set; }
    }
    public class DataVerifierBirthYearChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public int BirthYear { get; set; }
    }
}