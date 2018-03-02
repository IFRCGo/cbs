using System;
using doLittle.Events;

namespace Events.StaffUser 
{
    public class NewUserRegistered : IEvent 
    {
        public NewUserRegistered (Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registeredAt) 
        {
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

    public class NationalSocietyRegistered : IEvent 
    {
        public NationalSocietyRegistered (Guid staffUserId, Guid nationalSociety) 
        {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }

    public class NationalSocietyAssigned : IEvent 
    {
        public NationalSocietyAssigned (Guid staffUserId, Guid nationalSociety) 
        {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }

    public class PreferredLanguageRegistered : IEvent 
    {
        public PreferredLanguageRegistered (Guid staffUserId, int preferredLanguage) 
        {
            this.StaffUserId = staffUserId;
            this.PreferredLanguage = preferredLanguage;
        }
        public Guid StaffUserId { get; }
        public int PreferredLanguage { get; }
    } 

    public class PhoneNumberRegistered : IEvent 
    {
        public PhoneNumberRegistered (Guid staffUserId, string phoneNumber) 
        {
            this.StaffUserId = staffUserId;
            this.PhoneNumber = phoneNumber;
        }
        public Guid StaffUserId { get; }
        public string PhoneNumber { get; }
    } 

    public class SexRegistered : IEvent 
    {
        public SexRegistered (Guid staffUserId, int sex) 
        {
            this.StaffUserId = staffUserId;
            this.Sex = sex;
        }
        public Guid StaffUserId { get; }
        public int Sex { get; }
    } 

    public class BirthYearRegistered : IEvent 
    {
        public BirthYearRegistered (Guid staffUserId, int year) 
        {
            this.StaffUserId = staffUserId;
            this.BirthYear = year;
        }
        public Guid StaffUserId { get; }
        public int BirthYear { get; }
    } 
}