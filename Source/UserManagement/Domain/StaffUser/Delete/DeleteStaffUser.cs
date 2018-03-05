using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Delete
{
    public class DeleteStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public _Role Role { get; set; } //TODO: Change to different role type?
    }
}
