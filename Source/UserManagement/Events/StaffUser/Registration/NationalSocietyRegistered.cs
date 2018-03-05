using System;
using doLittle.Events;

namespace Events.StaffUser.Registration
{
    public class NationalSocietyRegistered : IEvent 
    {
        public NationalSocietyRegistered (Guid staffUserId, Guid nationalSociety) {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
    }
}