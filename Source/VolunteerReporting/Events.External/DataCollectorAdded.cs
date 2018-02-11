using System;
using doLittle.Events;
using System.Collections.Generic;

namespace Events.External
{
    public class DataCollectorAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
    }
}