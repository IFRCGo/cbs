using System;
using System.Collections.Generic;
using System.Text;

namespace Read.DataCollectors
{
    public class DataCollectorEventHandler : IDataCollectorsEventHandler
    {
        private readonly MongoDBHandler _dbHandler;

        public DataCollectorEventHandler(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }
        public void Handle(DataCollector @event)
        {
            throw new NotImplementedException();
        }
    }
}
