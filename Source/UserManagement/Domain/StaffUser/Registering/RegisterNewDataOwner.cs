using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwner : NewStaffRegistration<Domain.StaffUser.Roles.DataOwner>, IRequireLocation
    {
        public RegisterNewDataOwner()
        {
            Role = new Domain.StaffUser.Roles.DataOwner();
        } 

        public Location Location { get; set;}
        public string Position { get; set; }
        public string DutyStation { get; set; }
    }
}