namespace Concepts{
    public enum Role
    {
        Admin,
        DataVerifier,
        DataConsumer,
        DataCoordinator,
        SystemCoordinator,
        DataOwner
    }

    public static class RoleExtensions
    {
        public static bool RequiresExtensiveInfo(this Role r) =>
            r == Role.DataOwner
            || r == Role.DataCoordinator
            || r == Role.SystemCoordinator
            || r == Role.DataVerifier;

        public static bool RequiresPositionAndDutyStation(this Role r) =>
            r == Role.DataOwner;

        public static bool RequiresLocation(this Role r) =>
            RequiresExtensiveInfo(r)
            || r == Role.DataConsumer;

    }
}

