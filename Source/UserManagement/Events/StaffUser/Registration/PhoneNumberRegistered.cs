using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class PhoneNumberRegistered : IEvent 
    {
        public PhoneNumberRegistered (Guid staffUserId, string phoneNumber) {
            this.StaffUserId = staffUserId;
            this.PhoneNumber = phoneNumber;
        }
        public Guid StaffUserId { get; }
        public string PhoneNumber { get; }
    }
}