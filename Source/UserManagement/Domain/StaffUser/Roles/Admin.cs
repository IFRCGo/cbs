using System;
using System.Collections.Generic;
using Concepts;

namespace Domain.StaffUser.Roles
{
    public abstract class StaffRole : IHaveUserInfo
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
    public class Admin : StaffRole
    {

    }

    public class SystemConfigurator : StaffRole, ISupportBirthYear, ISupportSex, IRequireAssignedNationalSocieties,
        IRequireNationalSociety, IRequirePhoneNumbers, IRequirePreferredLanguage
    {
        public int? BirthYear { get; set; }
        public Sex? Sex { get; set; }
        public IEnumerable<Guid> AssignedNationalSocieties { get; set; }
        public Guid NationalSociety { get; set; }
        public Language? PreferredLanguage { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}