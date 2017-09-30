using System;

namespace Read
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        void Create(DataCollector dataCollector);
        void Update( DataCollector dataCollector);
    }
}