using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class DataOwner : Role 
    {
        public DataOwner() : base(RoleType.DataOwner)
        {
        }
    }
}