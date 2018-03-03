using System;

namespace Domain.StaffUser
{
    public delegate bool StaffUserIsRegistered(Guid staffUserId);

    public delegate bool CanAssignToNationalSociety(Guid nationalSociety);
}