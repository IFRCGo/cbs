using System;

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

    // public class SystemConfigurator : IHaveUserInfo, ISupportBirthYear, ISupportSex, IAmAssignedToNationalSocieties
    // {

    // }
}