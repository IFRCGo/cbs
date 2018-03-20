using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public interface IStaffUsers
    {
        T GetById<T>(Guid id)
            where T : BaseUser;
        Task<T> GetByIdAsync<T>(Guid id)
            where T : BaseUser;

        IEnumerable<T> GetAll<T>()
            where T : BaseUser;
        Task<IEnumerable<T>> GetAllAsync<T>()
            where T : BaseUser;

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save<T>(T dataCollector)
            where T : BaseUser;
        Task SaveAsync<T>(T dataCollector)
            where T : BaseUser;
    }
}