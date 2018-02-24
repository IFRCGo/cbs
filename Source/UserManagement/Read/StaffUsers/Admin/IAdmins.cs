using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.Admin
{
    public interface IAdmins
    {
        Admin GetById(Guid id);

        Task<Admin> GetByIdAsync(Guid id);
        IEnumerable<Admin> GetAll();

        Task<IEnumerable<Admin>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(Admin dataCollector);

        Task SaveAsync(Admin dataCollector);
    }
}