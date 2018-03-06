using System;
using System.Collections.Generic;
using Concepts;

namespace Read.StaffUsers.DataCoordinator
{
    public class DataCoordinator
    {
        public DataCoordinator(Guid staffUserId, int yearOfBirth, Sex sex, 
            Guid nationalSociety, Language preferredLanguage)
        {
            StaffUserId = staffUserId;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
        }

        public Guid StaffUserId { get; set; }
        
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        
        public List<PhoneNumber> MobilePhoneNumbers { get;  } 
            = new List<PhoneNumber>();
        public List<Guid> AssignedNationalSocieties { get; } 
            = new List<Guid>();
    }
}
