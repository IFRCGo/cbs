using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class DataConsumerUpdated : IEvent
    {
        public Guid StaffUserId { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }

        public double GpsLocationLatitude { get; private set; }
        public double GpsLocationLongitude { get; private set; }

        public DataConsumerUpdated(Guid staffUserId, string fullName, string displayName, string email, 
            double gpsLocationLatitude, double gpsLocationLongitude)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            GpsLocationLatitude = gpsLocationLatitude;
            GpsLocationLongitude = gpsLocationLongitude;
        }
    }
}