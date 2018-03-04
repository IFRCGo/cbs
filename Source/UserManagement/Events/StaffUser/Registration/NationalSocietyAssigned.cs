using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class NationalSocietyAssigned : IEvent 
    {
        public NationalSocietyAssigned (Guid staffUserId, Guid nationalSociety) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }
}