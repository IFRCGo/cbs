using System;
using Dolittle.Events;

namespace Events.StaffUser.Changing
{
    public class DataVerifierLocationChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
    }

    public class DataConsumerLocationChanged : IEvent
    {
        public Guid StaffUserId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
    }
}