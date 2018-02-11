using System;
using Concepts;

namespace Domain
{
    public class AddDataCollector
    {
        //TODO: Update these properties to reflect what is needed for event. Remove PhoneNumber
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string GpsLocation { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}