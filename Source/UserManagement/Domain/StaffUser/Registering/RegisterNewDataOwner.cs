using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwner : NewStaffRegistration<Domain.StaffUser.Roles.DataOwner>
    {
        public RegisterNewDataOwner()
        {
            Role = new Domain.StaffUser.Roles.DataOwner();
        } 
    }
}