using System.Collections.Generic;
using System;

namespace Domain.StaffUser
{
    public interface IRequireAssignedNationalSocieties
    {
         IEnumerable<Guid> AssignedNationalSocieties { get; }
    }
}