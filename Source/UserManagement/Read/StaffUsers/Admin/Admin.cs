using System;

namespace Read.StaffUsers.Admin
{
    public class Admin
    {
        //TODO: Probably deprecated when we have NewUserRegistered event
        //TODO: Update to the new system
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

    }
}
