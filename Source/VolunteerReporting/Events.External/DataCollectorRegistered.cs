using System;
using Dolittle.Events;
using System.Collections.Generic;

namespace Events.External
{
    public class DataCollectorRegistered : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}