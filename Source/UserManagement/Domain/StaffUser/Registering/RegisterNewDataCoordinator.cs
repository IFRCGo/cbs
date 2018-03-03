using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataCoordinator : NewExtendedRegistration, IAmAssignedToNationalSocieties
    {
        public IEnumerable<Guid> AssignedNationalSocieties { get; set;}
    }
}