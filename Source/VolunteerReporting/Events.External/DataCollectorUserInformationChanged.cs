using System;
using Dolittle.Events;
using System.Collections.Generic;

namespace Events.External
{
    public class DataCollectorUserInformationChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
    }
}