using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Update
{
    public abstract class BaseStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}