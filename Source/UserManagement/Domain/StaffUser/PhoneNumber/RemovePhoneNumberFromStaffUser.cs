using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Commands
{
    public class RemovePhoneNumberFromStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}