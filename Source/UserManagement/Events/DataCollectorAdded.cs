using System;
using Concepts;
using doLittle.Events;

namespace Events
{
    public class DataCollectorAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public int PreferredLanguage { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        //public string GpsLocation { get; set; }
        //public string MobilePhoneNumber { get; set; }
        //public string Email { get; set; }     
    }
}