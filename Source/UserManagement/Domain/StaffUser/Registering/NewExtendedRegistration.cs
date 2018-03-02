using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public abstract class NewExtendedRegistration : NewRegistration
    {
        public Role Role { get; set;}
    }
}