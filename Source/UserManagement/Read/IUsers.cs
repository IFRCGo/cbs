using System;
using System.Collections.Generic;

namespace Read
{
    public interface IUsers
    {
        StaffUser GetStaffUserById(Guid id);
        IEnumerable<StaffUser> GetAllStaffUsers();        
        bool DeleteUserById(Guid id);
        void Save(StaffUser user);
    }
}