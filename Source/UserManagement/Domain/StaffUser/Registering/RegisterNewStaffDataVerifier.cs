using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewStaffDataVerifier : NewExtendedRegistration<StaffDataVerifier>, IRequireLocation
    {
        public Location Location { get; set; }
    }
}