using System;

namespace Read.DataCollectors
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        void Save(DataCollector dataCollector);
    }
}