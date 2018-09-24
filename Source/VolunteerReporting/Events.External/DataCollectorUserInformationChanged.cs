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
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}