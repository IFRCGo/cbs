using System;
using System.Collections.Generic;
using Concepts;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.StaffUsers
{
    public class DataVerifier : BaseUser
    {
        public DataVerifier(Guid staffUserId, string fullName, string displayName,
            string email, DateTimeOffset registrationDate, int birthYear, Sex sex,
            Guid nationalSociety, Language preferredLanguage, Location location) 
            : base(staffUserId, fullName, displayName, email, registrationDate)
        {
            BirthYear = birthYear;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            Location = location;
        }

        [BsonRequired]
        public int BirthYear { get; set; }
        [BsonRequired]
        public Sex Sex { get; set; }
        [BsonRequired]
        public Guid NationalSociety { get; set; }
        [BsonRequired]
        public Language PreferredLanguage { get; set; }
        [BsonRequired]
        public Location Location { get; set; }

        public List<PhoneNumber> MobilePhoneNumbers { get; set; }
            = new List<PhoneNumber>();
        public List<Guid> AssignedNationalSociety { get; set; }
            = new List<Guid>();
    }
}