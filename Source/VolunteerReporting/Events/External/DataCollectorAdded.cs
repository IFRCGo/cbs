using System;
using Infrastructure.Events;
using System.Collections.Generic;

namespace Events.External
{
    public class DataCollectorAdded : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
    }
}