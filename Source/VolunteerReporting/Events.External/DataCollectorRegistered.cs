using System;
using Dolittle.Events;
using System.Collections.Generic;
using Dolittle.Artifacts;

namespace Events.External
{
    [Artifact("e32459e9-02c1-4da8-b2c8-d4c26f534856")]
    public class DataCollectorRegistered : IEvent
    {
        public DataCollectorRegistered(Guid dataCollectorId, string fullName, string displayName, double locationLongitude, double locationLatitude, string region, string district) 
        {
            this.DataCollectorId = dataCollectorId;
            this.FullName = fullName;
            this.DisplayName = displayName;
            this.LocationLongitude = locationLongitude;
            this.LocationLatitude = locationLatitude;
            this.Region = region;
            this.District = district;
               
        }
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }

        public string Region { get; }
        public string District { get; }
    }
}