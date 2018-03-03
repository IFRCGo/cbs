using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfigurator : NewExtendedRegistration, IAmAssignedToNationalSocieties
    {
        public IEnumerable<Guid> AssignedNationalSocieties { get; set;}
    }
}