using System;
using System.Collections.Generic;
using Concepts;

namespace Read.StaffUsers.DataOwner
{
    public class DataOwner
    {
        public DataOwner(Guid staffUserId, int yearOfBirth, Sex sex, 
            Guid nationalSociety, Language preferredLanguage, 
            Location location, string position, string dutyStation)
        {
            StaffUserId = staffUserId;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            Location = location;
            Position = position;
            DutyStation = dutyStation;
        }

        public Guid StaffUserId { get; set; }
       
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public string Position { get; set; }
        public string DutyStation { get; set; }

        public List<PhoneNumber> MobilePhoneNumbers { get; }
            = new List<PhoneNumber>();
        public List<Guid> AssignedNationalSocieties { get; }
            = new List<Guid>(); 
    }
}
