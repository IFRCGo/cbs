using System;
using doLittle.Events;

namespace Events.StaffUser.Registration
{
    public class DataCoordinatorRegistered : IEvent 
    {
        public DataCoordinatorRegistered (Guid staffUserId, Guid nationalSociety, int language, int sex, int birthYear) 
        {
            this.StaffUserId = staffUserId;
            this.NationalSociety = nationalSociety;
            this.PreferredLanguage = language;
            this.Sex = sex;
            this.BirthYear = birthYear;
        }
        public Guid StaffUserId { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public int BirthYear { get; set; }
        public int Sex { get; set; }
    }
}