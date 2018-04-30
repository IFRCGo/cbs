using System;
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

    //TODO: Really stupid way to do this...
    public static class RoleExtensions
    {
        public static StaffRole GetStaffRole(this Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    return new Admin();
                case Role.DataConsumer:
                    return new DataConsumer();
                case Role.DataCoordinator:
                    return new DataCoordinator();
                case Role.DataOwner:
                    return new DataOwner();
                case Role.DataVerifier:
                    return new DataVerifier();
                case Role.SystemCoordinator:
                    return new SystemConfigurator();

                default:
                    return null;
            }
        }

        public static bool HasPhoneNumbers(this StaffRole user)
            => user is IRequirePhoneNumbers || user is ISupportPhoneNumbers;

        public static bool HasPhoneNumbers(this Role role)
            => role.GetStaffRole() is IRequirePhoneNumbers || role.GetStaffRole() is ISupportPhoneNumbers;


        public static bool HasAssignedNationalSocieties(this StaffRole user) 
            => user is IRequireAssignedNationalSocieties;

        public static bool HasAssignedNationalSocieties(this Role role)
            => role.GetStaffRole() is IRequireAssignedNationalSocieties;


        public static bool HasBirthYear(this StaffRole user)
            => user is IRequireBirthYear || user is ISupportBirthYear;

        public static bool HasBirthYear(this Role role)
            => role.GetStaffRole() is IRequireBirthYear || role.GetStaffRole() is ISupportBirthYear;


        public static bool HasDutyStation(this StaffRole user)
            => user is IRequireDutyStation;

        public static bool HasDutyStation(this Role role)
            => role.GetStaffRole() is IRequireDutyStation;


        public static bool HasLocation(this StaffRole user)
            => user is IRequireLocation;

        public static bool HasLocation(this Role role)
            => role.GetStaffRole() is IRequireLocation;


        public static bool HasNationalSociety(this StaffRole user)
            => user is IRequireNationalSociety;

        public static bool HasNationalSociety(this Role role)
            => role.GetStaffRole() is IRequireNationalSociety;


        public static bool HasPosition(this StaffRole user)
            => user is IRequirePosition;

        public static bool HasPosition(this Role role)
            => role.GetStaffRole() is IRequirePosition;


        public static bool HasPreferredLanguage(this StaffRole user)
            => user is IRequirePreferredLanguage;

        public static bool HasPreferredLanguage(this Role role)
            => role.GetStaffRole() is IRequirePreferredLanguage;

        // ;) not during work hours I hope
        public static bool HasSex(this StaffRole user)
            => user is IRequireBirthYear || user is ISupportBirthYear;

        public static bool HasSex(this Role role)
            => role.GetStaffRole() is IRequireBirthYear || role.GetStaffRole() is ISupportBirthYear;
    }
}