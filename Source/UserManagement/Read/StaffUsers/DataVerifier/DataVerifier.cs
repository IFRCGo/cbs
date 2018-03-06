using System;
using System.Collections.Generic;
using Concepts;

namespace Read.StaffUsers.DataVerifier
{
    public class DataVerifier
    {
        public DataVerifier(Guid staffUserId, int yearOfBirth, Sex sex, 
            Guid nationalSociety, Language preferredLanguage, Location location)
        {
            StaffUserId = staffUserId;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            Location = location;
        }

        public Guid StaffUserId { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }

        public List<PhoneNumber> MobilePhoneNumbers { get; }
            = new List<PhoneNumber>();
        public List<Guid> AssignedNationalSociety { get; }
            = new List<Guid>();
    }
}
