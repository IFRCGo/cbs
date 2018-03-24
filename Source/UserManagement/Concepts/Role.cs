namespace Concepts{
    public enum Role
    {
        Admin = 0,
        DataVerifier,
        DataConsumer,
        DataCoordinator,
        SystemCoordinator,
        DataOwner
    }

    public static class RoleExtensions
    {
        public static bool RequiresAgeAndSex(this Role r) =>
            r == Role.DataVerifier;
        
        /// <summary>
        /// Represents if NationalSociety, PrefferedLanguage and MobilePhoneNumbers is mandatory for the given Role r
        /// </summary>
        /// <param name="r">Staff role</param>
        /// <returns>true if mandatory</returns>
        public static bool RequiresExtensiveInfo(this Role r) =>
            r == Role.DataOwner
            || r == Role.DataCoordinator
            || r == Role.SystemCoordinator
            || r == Role.DataVerifier;

        public static bool RequiresPositionAndDutyStation(this Role r) =>
            r == Role.DataOwner;

        public static bool RequiresLocation(this Role r) =>
            r == Role.DataVerifier 
            || r == Role.DataConsumer;

        public static bool RequiresAssignedNationalSocieties(this Role r) =>
            r == Role.SystemCoordinator
            || r == Role.DataCoordinator;
    }
}

