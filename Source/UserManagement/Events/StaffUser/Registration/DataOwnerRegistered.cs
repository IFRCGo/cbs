using System;
using doLittle.Events;

namespace Events.StaffUser.Registration
{
    public class DataOwnerRegistered : IEvent 
    {
        public DataOwnerRegistered (Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registeredAt, Guid nationalSociety, int language, 
            int sex, int birthYear, double latitude, double longitude, 
            string position, string dutyStation) 
        {
            this.DutyStation = dutyStation;
            this.Position = position;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegisteredAt = registeredAt;
            this.NationalSociety = nationalSociety;
            this.PreferredLanguage = language;
            this.Sex = sex;
            this.BirthYear = birthYear;

        }
        public Guid StaffUserId { get; }

        public string FullName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public DateTimeOffset RegisteredAt { get; }

        public double Latitude { get; }
        public double Longitude { get; }
        public string Position { get; }
        public string DutyStation { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }

    //TODO: Shouldn't this be in its own file?
    public class StaffDataConsumerRegistered : IEvent 
    {
        public StaffDataConsumerRegistered (Guid staffUserId, string fullName, string displayName,
            string email, DateTimeOffset registeredAt, Guid nationalSociety, int language, 
            int sex, int birthYear, double latitude, double longitude) 
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegisteredAt = registeredAt;
            this.NationalSociety = nationalSociety;
            this.PreferredLanguage = language;
            this.Sex = sex;
            this.BirthYear = birthYear;

        }
        public Guid StaffUserId { get; }

        public string FullName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public DateTimeOffset RegisteredAt { get; }

        public double Latitude { get; }
        public double Longitude { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }    
}