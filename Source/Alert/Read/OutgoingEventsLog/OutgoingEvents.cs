using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
    public class OutgoingEvents : Repository<OutgoingEvent>, IOutgoingEvents
    {
        public OutgoingEvents(IMongoDatabase database) : base(database, "OutgoingEvents")
        {
        }
    }
}
