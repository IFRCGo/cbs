using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataOwner : NewExtendedRegistration<DataOwner>, IHaveALocation
    {
        public Location Location { get; set;}
        public string Position { get; set; }
        public string DutyStation { get; set; }
    }
}