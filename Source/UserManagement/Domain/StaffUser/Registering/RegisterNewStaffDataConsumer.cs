using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumer : NewStaffRegistration<Domain.StaffUser.Roles.DataConsumer>
    {
        public RegisterNewStaffDataConsumer()
        {
            Role = new Domain.StaffUser.Roles.DataConsumer();
        }
    }
}