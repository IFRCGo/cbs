using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorVillageChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}