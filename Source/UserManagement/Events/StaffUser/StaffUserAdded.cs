using System;
using Concepts;
using doLittle.Events;

namespace Events
{
    public class StaffUserAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; } //Question from Bjørn: Is date or year of birth better?
        public Sex Sex { get; set; } //TODO: Should not use enum in events. Only primitive types
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; } //TODO: Should not use enum in events. Only primitive types

        public Location Location { get; set; }
        public string GeoLocation { get; set; } //TODO from Bjørn: Change to double LocationLongitude and double LocationLatitude
        public string MobilePhoneNumber { get; set; } //TODO from Bjørn: Move into sepperate event since it is optional
        public string Email { get; set; } //TODO from Bjørn: Move into sepperate event since it is optional
    }
}
