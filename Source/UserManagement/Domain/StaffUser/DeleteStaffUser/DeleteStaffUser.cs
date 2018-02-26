using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Commands
{
    public class DeleteStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public Role Role { get; set; }
    }
}
