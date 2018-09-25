using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("b0121c6e-fe6f-45e6-a669-6fc0382fac29")]
    public class DataCollectorRemoved : IEvent
    {
        public DataCollectorRemoved(Guid dataCollectorId) 
        {
            this.DataCollectorId = dataCollectorId;
               
        }
        public Guid DataCollectorId { get; }

    }
}