using System;
using Concepts;

namespace Domain.StaffUser.Update
{
    public abstract class CoordinatorStaffUser : ExtendedStaffUser
    {
        public Guid[] AssignedNationalSocieties { get; set; }
    }
}