using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public class SystemConfigurator : Role 
    {
        public SystemConfigurator() : base(RoleType.SystemConfigurator)
        {
        }
    }
}