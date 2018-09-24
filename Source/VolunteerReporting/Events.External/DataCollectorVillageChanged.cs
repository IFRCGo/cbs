using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("019edaf2-25ab-49e8-95eb-fbd034654025")]
    public class DataCollectorVillageChanged : IEvent
    {
        public DataCollectorVillageChanged(Guid dataCollectorId, string village) 
        {
            this.DataCollectorId = dataCollectorId;
            this.Village = village;
               
        }
        public Guid DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}