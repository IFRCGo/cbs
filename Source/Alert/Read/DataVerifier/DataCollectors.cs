using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Read.Disease;

namespace Read
{
    public class DataCollectors : Repository<DataCollector>, IDataCollectors
    {
        public DataCollectors(IMongoDatabase database) : base(database, "DataVerifier")
        {
        }

        public IEnumerable<DataCollector> Get(Guid[] ids)
        {
            return _collection.FindSync(o => ids.Contains(o.UserId)).ToEnumerable();
        }
    }
}
