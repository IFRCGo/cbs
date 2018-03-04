using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewAdminUser : NewStaffRegistration<Domain.StaffUser.Roles.Admin>
    {
        public RegisterNewAdminUser()
        {
            Role = new Domain.StaffUser.Roles.Admin();
        }
    }
}