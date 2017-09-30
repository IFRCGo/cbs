using System;
using System.Collections.Generic;

namespace Read
{
    public interface IUsers
    {
        StaffUser GetStaffUserById(Guid id);
        VolunteerUser GetVolunteerUserById(Guid id);
        IEnumerable<StaffUser> GetAllStaffUsers();
        IEnumerable<VolunteerUser> GetAllVolunteerUsers();
        void Save(StaffUser user);
        void Save(VolunteerUser user);
    }
}