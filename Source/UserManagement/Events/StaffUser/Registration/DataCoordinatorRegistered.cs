using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class DataCoordinatorRegistered : IEvent 
    {
        public DataCoordinatorRegistered (Guid staffUserId, string fullName, 
            string displayName, string email, DateTimeOffset registeredAt, 
            Guid nationalSociety, int language, int sex, int birthYear) 
        {
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
        public Guid StaffUserId { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        public Guid NationalSociety { get; set; }
        public int PreferredLanguage { get; set; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }
}