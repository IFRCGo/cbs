using System;
using Dolittle.Events;
using System.Collections.Generic;
using Dolittle.Artifacts;

namespace Events.External
{
    [Artifact("5c95f21a-1790-4f80-b7a5-dbe2416ef7d4")]
    public class DataCollectorUserInformationChanged : IEvent
    {
        public DataCollectorUserInformationChanged(Guid dataCollectorId, string fullName, string displayName, string region, string district) 
        {
            this.DataCollectorId = dataCollectorId;
            this.FullName = fullName;
            this.DisplayName = displayName;
            this.Region = region;
            this.District = district;
               
        }
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }

        public string Region { get; }
        public string District { get; }
    }
}