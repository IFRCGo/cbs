using System;
using doLittle.Events;

namespace Events.StaffUser.Registration
{
    public class SystemConfiguratorRegistered : IEvent 
    {
        public SystemConfiguratorRegistered (Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registeredAt, Guid nationalSociety, int language, 
            int sex, int birthYear) 
        {
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

        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }
}