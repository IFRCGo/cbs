using System;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public interface IAmAssignedToNationalSocieties
    {
        IEnumerable<Guid> AssignedNationalSocieties { get; }
    }
}