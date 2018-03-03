using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public abstract class NewExtendedRegistration<T> : NewRegistration where T : Role
    {
        public T Role { get; set;}
    }
}