using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorLocationChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }

        public DataCollectorLocationChanged(Guid dataCollectorId, double locationLatitude, double locationLongitude)
        {
            DataCollectorId = dataCollectorId;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }
    }
}