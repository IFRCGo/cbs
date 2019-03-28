using System;
using System.Collections.Generic;
using System.Text;

namespace Read.DataCollectors
{
    public interface IDataCollectorsEventHandler
    {
        void Handle(DataCollector @event);
    }
}
