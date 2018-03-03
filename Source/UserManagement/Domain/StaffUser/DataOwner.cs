using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class DataOwner : StaffRole 
    {
        public DataOwner() : base(RoleType.DataOwner)
        {
        }
    }
}