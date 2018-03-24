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
    }
}