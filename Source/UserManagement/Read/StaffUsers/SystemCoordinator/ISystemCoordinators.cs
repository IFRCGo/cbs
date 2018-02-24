using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.SystemCoordinator
{
    public interface ISystemCoordinators
    {
        SystemCoordinator GetById(Guid id);

        Task<SystemCoordinator> GetByIdAsync(Guid id);
        IEnumerable<SystemCoordinator> GetAll();

        Task<IEnumerable<SystemCoordinator>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(SystemCoordinator dataCollector);

        Task SaveAsync(SystemCoordinator dataCollector);
    }
}