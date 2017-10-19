using System;
using Events.External;

namespace Read.Disease
{
    public class DataCollector : Entity
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public LongLat Position { get; set; }
        public DataVerifier DataVerifier { get; set; }
    }
}
