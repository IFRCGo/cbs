using System;
using Concepts;

namespace Domain.StaffUser.Add
{
    public class CoordinatorStaffUser : ExtendedStaffUser
    {
        
        public Guid[] AssignedNationalSocieties { get; set; }
    }
}