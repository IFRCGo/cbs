using System;
using System.Collections.Generic;
using Concepts;

namespace Read.StaffUsers.DataVerifier
{
    public class DataVerifier
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        //public string GeoLocation { get; set; } 
        public List<string> MobilePhoneNumbers { get; set; }
        public bool MobilePhoneNumberConfirmed { get; } = true;
        public List<Guid> AssignedNationalSociety { get; set; }
        public DateTimeOffset RegistrationDateTime { get; set; }
    }
}