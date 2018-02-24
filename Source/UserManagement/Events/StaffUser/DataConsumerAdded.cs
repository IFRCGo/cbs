using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events.StaffUser
{
    public class DataConsumerAdded : IEvent
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
        public double LocationLongitude { get; private set; }
        public double LocationLatitude { get; private set; }

        public DataConsumerAdded(Guid id, string fullName, string displayName, string email, double locationLongitude, double locationLatitude)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
        }
    }
}
