using System;
using System.Collections.Generic;

namespace Read
{
    public interface IUsers
    {
        StaffUser GetStaffUserById(Guid id);
        DataCollector GetDataCollectorById(Guid id);
        IEnumerable<StaffUser> GetAllStaffUsers();
        IEnumerable<DataCollector> GetAllDataCollectors();
        void Save(StaffUser user);
        void Save(DataCollector user);
    }
}