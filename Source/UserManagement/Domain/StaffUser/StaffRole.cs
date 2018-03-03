using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public abstract class StaffRole : Role 
    {
        protected StaffRole(RoleType type) : base(type)
        {}
        public Guid NationalSociety { get; set; }
    }
}