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
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}