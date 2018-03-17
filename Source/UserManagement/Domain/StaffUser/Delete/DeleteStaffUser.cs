using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Delete
{
    public class DeleteStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
    }
}
