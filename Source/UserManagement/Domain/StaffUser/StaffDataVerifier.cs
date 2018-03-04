using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class StaffDataVerifier : StaffRole 
    {
        public StaffDataVerifier() : base(RoleType.StaffDataVerifier)
        {
        }
    }
}