using System;
using Dolittle.Events;

namespace Events.External
{
    public class DataCollectorVillageChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string Village { get; set; }
    }
}