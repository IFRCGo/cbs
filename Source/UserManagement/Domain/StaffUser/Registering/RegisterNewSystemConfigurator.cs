using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfigurator : NewStaffRegistration<Domain.StaffUser.Roles.SystemConfigurator>
    {
        public RegisterNewSystemConfigurator()
        {
            Role = new Domain.StaffUser.Roles.SystemConfigurator();
        }
    }
}