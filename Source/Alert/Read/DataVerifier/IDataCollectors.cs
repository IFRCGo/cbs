using System;
using System.Collections.Generic;
using Read.Disease;

namespace Read
{
    public interface IDataCollectors
    {
        IEnumerable<DataCollector> Get(Guid[] ids);
    }
}