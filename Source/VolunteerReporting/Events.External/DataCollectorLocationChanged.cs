using System;
using Dolittle.Events;

namespace Events.External
{
    public class DataCollectorLocationChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
    }
}