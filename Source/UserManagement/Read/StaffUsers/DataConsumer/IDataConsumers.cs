using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.StaffUsers.DataConsumer
{
    public interface IDataConsumers
    {
        DataConsumer GetById(Guid id);

        Task<DataConsumer> GetByIdAsync(Guid id);
        IEnumerable<DataConsumer> GetAll();

        Task<IEnumerable<DataConsumer>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(DataConsumer dataCollector);

        Task SaveAsync(DataConsumer dataCollector);
    }
}