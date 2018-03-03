using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public class SystemConfigurator : StaffRole 
    {
        public SystemConfigurator() : base(RoleType.SystemConfigurator)
        {
        }
    }
}