using System;
using Dolittle.Events;

namespace Events.StaffUser.Registration
{
    public class NationalSocietyAssigned : IEvent 
    {
        public NationalSocietyAssigned (Guid staffUserId, Guid nationalSociety) {
            StaffUserId = staffUserId;
            NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }
}