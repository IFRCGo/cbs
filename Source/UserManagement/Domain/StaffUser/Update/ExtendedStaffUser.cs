using System;
using Concepts;

namespace Domain.StaffUser.Update
{
    public abstract class ExtendedStaffUser : BaseStaffUser
    {
        public Location Location { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string[] PhoneNumbers { get; set; }
    }
}