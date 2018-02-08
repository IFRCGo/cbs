using System;
using System.Collections.Generic;

namespace Read.DataCollectors
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        IEnumerable<DataCollector> GetAllDataCollectors();
        void Save(DataCollector dataCollector);
    }
}