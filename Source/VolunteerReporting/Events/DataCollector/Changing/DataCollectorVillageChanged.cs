using System;
using Dolittle.Events;

namespace Events.DataCollectors.Changing
{
    public class DataCollectorVillageChanged : IEvent
    {
        public DataCollectorVillageChanged(Guid dataCollectorId, string village) 
        {
            this.DataCollectorId = dataCollectorId;
            this.Village = village;
               
        }
        public Guid DataCollectorId { get; }
        public string Village { get; }

        
    }
}