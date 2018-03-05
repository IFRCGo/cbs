using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.DataCoordinator
{
    public interface IDataCoordinators
    {
        DataCoordinator GetById(Guid id);

        Task<DataCoordinator> GetByIdAsync(Guid id);
        IEnumerable<DataCoordinator> GetAll();

        Task<IEnumerable<DataCoordinator>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(DataCoordinator dataCollector);

        Task SaveAsync(DataCoordinator dataCollector);
    }
}