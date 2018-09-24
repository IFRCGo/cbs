using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("c7343b03-263f-4920-908e-64234a5151ec")]
    public class DataCollectorLocationChanged : IEvent
    {
        public DataCollectorLocationChanged(Guid dataCollectorId, double locationLatitude, double locationLongitude) 
        {
            this.DataCollectorId = dataCollectorId;
            this.LocationLatitude = locationLatitude;
            this.LocationLongitude = locationLongitude;
               
        }
        public Guid DataCollectorId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
    }
}