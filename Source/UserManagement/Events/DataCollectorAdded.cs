using System;
using Concepts.enums;
using doLittle.Events;

namespace Events
{
    public class DataCollectorAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string GpsLocation { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }

        //TODO: Change to longtitude and latitude. Also remove mobile and email(optional) into sepperate events. Same with preffered language?
        //TODO: Change long and lat to decimal in all places where it is used
        // public Guid Id { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public double LocationLongitude { get; set; }
        // public double LocationLatitude { get; set; }
    }
}