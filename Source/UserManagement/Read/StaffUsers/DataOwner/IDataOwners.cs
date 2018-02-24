using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.DataOwner
{
    public interface IDataOwners
    {
        DataOwner GetById(Guid id);

        Task<DataOwner> GetByIdAsync(Guid id);
        IEnumerable<DataOwner> GetAll();

        Task<IEnumerable<DataOwner>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(DataOwner dataCollector);

        Task SaveAsync(DataOwner dataCollector);
    }
}