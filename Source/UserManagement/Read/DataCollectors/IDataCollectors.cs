using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public interface IDataCollectors : IExtendedReadModelRepositoryFor<DataCollector>
    {
        DataCollector GetById(Guid id);
        Task<DataCollector> GetByIdAsync(Guid id);

        IEnumerable<DataCollector> GetAll();

        Task<IEnumerable<DataCollector>> GetAllAsync();
    }
}