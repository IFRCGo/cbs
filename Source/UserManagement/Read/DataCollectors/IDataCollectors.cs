using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
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