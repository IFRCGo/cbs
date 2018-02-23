using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events.StaffUser
{
    public class DataConsumerAdded : IEvent
    {
        /*
         * public Guid Id { get; set; }
        public String FullName { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public Location Area { get; set; }
         */
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
        public double AreaLongitude { get; private set; }//Todo: Or String? What is Area?
        public double AreaLatitude { get; private set; }

        public DataConsumerAdded(Guid id, string fullName, string displayName, string email, double areaLongitude, double areaLatitude)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            AreaLongitude = areaLongitude;
            AreaLatitude = areaLatitude;
        }
    }
}
