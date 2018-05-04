using System;
using Events.StaffUser.Changing;
using MongoDB.Driver;

namespace Read.StaffUsers.Admin
{
    public interface IAdminRepository : IReadModelRepositoryForStaffUser<Models.Admin>
    {
        
    }
}