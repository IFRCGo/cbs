using System;
using Concepts;

namespace Read.StaffUsers.DataConsumer
{
    public class DataConsumer
    {
        public DataConsumer(Guid staffUserId, Location location, 
            Guid nationalSociety, Language preferredLanguage, 
            int birthYear, Sex sex)

        {
            StaffUserId = staffUserId;
            Location = location;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            BirthYear = birthYear;
            Sex = sex;
        }
        public Guid StaffUserId { get; set; }
        public Location Location { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public int BirthYear { get; set; }
        public Sex Sex { get; set; }
        
    }
}
