using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class PhoneNumberRemovedFromStaffUser : IEvent
    {
        public Guid StaffUserId { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Role { get; private set; }

        public PhoneNumberRemovedFromStaffUser(Guid staffUserId, string phoneNumber, int role)
        {
            StaffUserId = staffUserId;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}