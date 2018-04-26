using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class PhoneNumberRegistered : IEvent 
    {
        public PhoneNumberRegistered (Guid staffUserId, string phoneNumber) {
            StaffUserId = staffUserId;
            PhoneNumber = phoneNumber;
        }
        public Guid StaffUserId { get; }
        public string PhoneNumber { get; }
    }
}