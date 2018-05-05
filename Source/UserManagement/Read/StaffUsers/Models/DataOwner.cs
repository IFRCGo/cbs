using System;
using System.Collections.Generic;
using Concepts;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.StaffUsers.Models
{
    public class DataOwner : BaseUser
    {
        public DataOwner(Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registrationDate, int birthYear, Sex sex, 
            Guid nationalSociety, Language preferredLanguage,
            string position, string dutyStation) 
            : base(staffUserId, fullName, displayName, email, registrationDate)
        {
            BirthYear = birthYear;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            Position = position;
            DutyStation = dutyStation;

            PhoneNumbers = new List<PhoneNumber>();
            AssignedNationalSocieties = new List<Guid>();
        }

        public int BirthYear { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string Position { get; set; }
        public string DutyStation { get; set; }
        
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Guid> AssignedNationalSocieties { get; set; }
    }
}