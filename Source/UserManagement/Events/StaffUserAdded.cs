using System;
using Concepts.enums;
using Infrastructure.Events;

namespace Events
{
    public class StaffUserAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string Location { get; set; }
        public string GeoLocation { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
