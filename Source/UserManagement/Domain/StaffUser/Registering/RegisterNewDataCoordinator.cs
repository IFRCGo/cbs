using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataCoordinator : NewStaffRegistration<Domain.StaffUser.Roles.DataCoordinator>
    {        
        public RegisterNewDataCoordinator()
        {
            Role = new Domain.StaffUser.Roles.DataCoordinator();
        }
    }
}