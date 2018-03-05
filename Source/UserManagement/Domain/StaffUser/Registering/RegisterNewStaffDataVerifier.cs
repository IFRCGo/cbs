using System;
using System.Collections.Generic;
using Concepts;

namespace Domain.StaffUser.Registering {

    public class RegisterNewStaffDataVerifier : NewStaffRegistration<Roles.DataVerifier>
    {
        public RegisterNewStaffDataVerifier () 
        {
            Role = new Roles.DataVerifier();    
        }
        //public Location Location { get; set; }
        //public int BirthYear { get; set; }
        //public Guid NationalSociety { get; set; }
        //public Sex? Sex { get; set; }
        //public IEnumerable<string> PhoneNumbers { get; set; }
        //public Language? PreferredLanguage { get; set; }
    }
}