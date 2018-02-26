using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.AddStaffUser
{
    public class BaseStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public Role Role { get; protected set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}