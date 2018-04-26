using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class StaffDataVerifierRegistered : IEvent 
    {
        public StaffDataVerifierRegistered (Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registeredAt, Guid nationalSociety, int language, 
            int sex, int birthYear, double latitude, double longitude) 
        {
            Longitude = longitude;
            Latitude = latitude;
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegisteredAt = registeredAt;
            NationalSociety = nationalSociety;
            PreferredLanguage = language;
            Sex = sex;
            BirthYear = birthYear;

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
        public int BirthYear { get; }
        public int Sex { get; }
    }
}