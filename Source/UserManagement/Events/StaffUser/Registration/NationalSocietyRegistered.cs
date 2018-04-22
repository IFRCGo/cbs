using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class NationalSocietyRegistered : IEvent 
    {
        public NationalSocietyRegistered (Guid staffUserId, Guid nationalSociety) {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }
}