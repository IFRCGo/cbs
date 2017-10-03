using System;

namespace Read
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        void Save(DataCollector dataCollector);
    }
}