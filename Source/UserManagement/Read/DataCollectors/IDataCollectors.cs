using System.Collections.Generic;
using Concepts.DataCollector;
using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors
{
    public interface IDataCollectors : IExtendedReadModelRepositoryFor<DataCollector>
    {
        DataCollector GetById(DataCollectorId id);

        IEnumerable<DataCollector> GetAll();
    }
}