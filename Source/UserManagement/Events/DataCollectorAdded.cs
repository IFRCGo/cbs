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
        public int Age { get; set; } //Question from Bjørn: Is date or year of birth better?
        public Sex Sex { get; set; } //TODO: Should not use enum in events. Only primitive types
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; } //TODO: Should not use enum in events. Only primitive types
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        //public string GpsLocation { get; set; }
        //public string MobilePhoneNumber { get; set; }
        //public string Email { get; set; }     
    }
}