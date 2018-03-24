using System;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.PhoneNumber
{
    public class AddPhoneNumberToStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public string PhoneNumber { get; set; }
    }
}