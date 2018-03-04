using System;
using doLittle.Events;

namespace Events.StaffUser
{
    public class PreferredLanguageRegistered : IEvent 
    {
        public PreferredLanguageRegistered (Guid staffUserId, int preferredLanguage) {
            this.StaffUserId = staffUserId;
            this.PreferredLanguage = preferredLanguage;
        }
        public Guid StaffUserId { get; }
        public int PreferredLanguage { get; }
    }
}