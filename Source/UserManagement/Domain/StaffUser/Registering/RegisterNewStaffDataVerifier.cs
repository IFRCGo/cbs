using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering {

    public class RegisterNewStaffDataVerifier : NewStaffRegistration<Domain.StaffUser.Roles.DataVerifier>, IRequireLocation,
        IRequireBirthYear, IRequirePreferredLanguage, IRequireSex, IRequireNationalSociety, IRequirePhoneNumbers 
    {
        public RegisterNewStaffDataVerifier () 
        {
            Role = new Domain.StaffUser.Roles.DataVerifier();    
        }
        public Location Location { get; set; }
        public int BirthYear { get; set; }
        public Guid NationalSociety { get; set; }
        public Sex? Sex { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public Language? PreferredLanguage { get; set; }
    }
}