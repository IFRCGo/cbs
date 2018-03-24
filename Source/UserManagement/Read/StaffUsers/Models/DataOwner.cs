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
        [BsonRequired]
        public Guid NationalSociety { get; set; }
        [BsonRequired]
        public Language PreferredLanguage { get; set; }
        [BsonRequired]
        public string Position { get; set; }
        [BsonRequired]
        public string DutyStation { get; set; }

        [BsonRequired]
        public List<PhoneNumber> PhoneNumbers { get; set; }
        [BsonRequired]
        public List<Guid> AssignedNationalSocieties { get; set; }
    }
}