using System;
using Concepts;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.StaffUsers.Models
{
    public class DataConsumer : BaseUser
    {
        public DataConsumer(Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registrationDate, Location location, 
            Guid nationalSociety, Language preferredLanguage, int birthYear, Sex sex) 
            : base(staffUserId, fullName, displayName, email, registrationDate)
        {
            Location = location;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            BirthYear = birthYear;
            Sex = sex;
        }
        
        public Location Location { get; set; }
        public Guid NationalSociety { get; set; }

        public Language PreferredLanguage { get; set; }
        public int BirthYear { get; set; }
        public Sex Sex { get; set; }
    }
}