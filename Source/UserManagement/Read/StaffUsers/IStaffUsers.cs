using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers
{
    public interface IStaffUsers
    {
        StaffUser GetById(Guid id);

        Task<StaffUser> GetByIdAsync(Guid id);
        IEnumerable<StaffUser> GetAll();

        Task<IEnumerable<StaffUser>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(StaffUser dataCollector);

        Task SaveAsync(StaffUser dataCollector);
    }
}