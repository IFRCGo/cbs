using System;
using doLittle.Events;

namespace Events.StaffUser.Registration
{
    public class PreferredLanguageRegistered : IEvent 
    {
        public PreferredLanguageRegistered (Guid staffUserId, int preferredLanguage) {
            StaffUserId = staffUserId;
            PreferredLanguage = preferredLanguage;
        }
        public Guid StaffUserId { get; }
        public int PreferredLanguage { get; }
    }
}