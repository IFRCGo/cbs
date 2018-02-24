using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.DataVerifier
{
    public interface IDataVerifiers
    {
        DataVerifier GetById(Guid id);

        Task<DataVerifier> GetByIdAsync(Guid id);
        IEnumerable<DataVerifier> GetAll();

        Task<IEnumerable<DataVerifier>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(DataVerifier dataCollector);

        Task SaveAsync(DataVerifier dataCollector);
    }
}