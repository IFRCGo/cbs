using System;
using System.Collections.Generic;
using Concepts;

namespace Domain.StaffUser.Roles
{
    public class DataVerifier : StaffRole, ISupportBirthYear, ISupportSex, IRequireNationalSociety, IRequirePhoneNumbers, 
        IRequirePreferredLanguage, IRequireLocation
    {
        public int? BirthYear { get; set; }
        public Sex? Sex { get; set; }
        public IEnumerable<Guid> AssignedNationalSocieties { get; set; }
        public Guid NationalSociety { get; set; }
        public Language? PreferredLanguage { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public Location Location { get; set; }
    }    
}