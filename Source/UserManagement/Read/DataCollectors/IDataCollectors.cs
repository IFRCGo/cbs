using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors
{
    public interface IDataCollectors : IExtendedReadModelRepositoryFor<DataCollector>
    {
        DataCollector GetById(DataCollectorId id);
        Task<DataCollector> GetByIdAsync(DataCollectorId id);

        IEnumerable<DataCollector> GetAll();

        Task<IEnumerable<DataCollector>> GetAllAsync();
    }
}