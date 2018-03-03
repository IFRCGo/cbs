using System;
using doLittle.Events;

namespace Events.StaffUser {
    public class NewUserRegistered : IEvent {
        public NewUserRegistered (Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registeredAt) {
            this.StaffUserId = staffUserId;
            this.FullName = fullName;
            this.DisplayName = displayName;
            this.Email = email;
            this.RegisteredAt = registeredAt;
        }
        public Guid StaffUserId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public DateTimeOffset RegisteredAt { get; }
    }

    public class SystemConfiguratorRegistered : IEvent {
        public SystemConfiguratorRegistered (Guid staffUserId, Guid nationalSociety, int language, int sex, int birthYear) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
            this.PreferredLanguage = language;
            this.Sex = sex;
            this.BirthYear = birthYear;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }
    
    public class DataCoordinatorRegistered : IEvent 
    {
        public DataCoordinatorRegistered (Guid staffUserId, Guid nationalSociety, int language, int sex, int birthYear) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
            this.PreferredLanguage = language;
            this.Sex = sex;
            this.BirthYear = birthYear;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }

    public class DataOwnerRegistered : IEvent 
    {
        public DataOwnerRegistered (Guid staffUserId, double latitude, double longitude, string position, string dutyStation) 
        {
            this.DutyStation = dutyStation;
            this.Position = position;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.StaffUserId = staffUserId;

        }
        public Guid StaffUserId { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public string Position { get; }
        public string DutyStation { get; }
    }

    public class NationalSocietyRegistered : IEvent {
        public NationalSocietyRegistered (Guid staffUserId, Guid nationalSociety) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }

    public class NationalSocietyAssigned : IEvent {
        public NationalSocietyAssigned (Guid staffUserId, Guid nationalSociety) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }

    public class PreferredLanguageRegistered : IEvent {
        public PreferredLanguageRegistered (Guid staffUserId, int preferredLanguage) {
            this.StaffUserId = staffUserId;
            this.PreferredLanguage = preferredLanguage;
        }
        public Guid StaffUserId { get; }
        public int PreferredLanguage { get; }
    }

    public class PhoneNumberRegistered : IEvent {
        public PhoneNumberRegistered (Guid staffUserId, string phoneNumber) {
            this.StaffUserId = staffUserId;
            this.PhoneNumber = phoneNumber;
        }
        public Guid StaffUserId { get; }
        public string PhoneNumber { get; }
    }
}