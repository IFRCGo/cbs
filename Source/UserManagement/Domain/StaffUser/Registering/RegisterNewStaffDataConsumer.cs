using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumer : NewExtendedRegistration<StaffDataConsumer>, IRequireLocation
    {
        public Location Location { get; set;}
        public string Position { get; set; }
    }
}