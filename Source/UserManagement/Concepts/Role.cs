namespace Concepts{
    public enum _Role
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
        public static bool RequiresAgeAndSex(this _Role r) =>
            r == _Role.DataVerifier;
        
        /// <summary>
        /// Represents if NationalSociety, PrefferedLanguage and MobilePhoneNumbers is mandatory for the given Role r
        /// </summary>
        /// <param name="r">Staff role</param>
        /// <returns>true if mandatory</returns>
        public static bool RequiresExtensiveInfo(this _Role r) =>
            r == _Role.DataOwner
            || r == _Role.DataCoordinator
            || r == _Role.SystemCoordinator
            || r == _Role.DataVerifier;

        public static bool RequiresPositionAndDutyStation(this _Role r) =>
            r == _Role.DataOwner;

        public static bool RequiresLocation(this _Role r) =>
            r == _Role.DataVerifier 
            || r == _Role.DataConsumer;

        public static bool RequiresAssignedNationalSocieties(this _Role r) =>
            r == _Role.SystemCoordinator
            || r == _Role.DataCoordinator;
    }
}

