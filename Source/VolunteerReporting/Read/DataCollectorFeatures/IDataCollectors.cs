using System;

namespace Read
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        DataCollector GetByMobilePhoneNumber(string MobilePhoneNumber);
        void Save(DataCollector dataCollector);
    }
}