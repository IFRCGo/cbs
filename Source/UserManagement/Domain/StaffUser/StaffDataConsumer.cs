using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class StaffDataConsumer : StaffRole 
    {
        public StaffDataConsumer() : base(RoleType.StaffDataConsumer)
        {
        }
    }
}