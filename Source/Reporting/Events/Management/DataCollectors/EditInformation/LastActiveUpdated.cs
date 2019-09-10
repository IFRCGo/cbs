using System;
using Dolittle.Events;

namespace Events.Management.DataCollectors.EditInformation
{
    public class LastActiveUpdated : IEvent
    {
        public DateTimeOffset LastActive { get; }

        public LastActiveUpdated(DateTimeOffset lastActive)
        {
            LastActive = lastActive;
        }
    }
}
