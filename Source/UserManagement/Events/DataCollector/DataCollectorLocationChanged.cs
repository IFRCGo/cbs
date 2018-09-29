using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorLocationChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public double LocationLatitude { get; }
        public double LocationLongitude { get; }

        public DataCollectorLocationChanged(Guid dataCollectorId, double locationLatitude, double locationLongitude)
        {
            DataCollectorId = dataCollectorId;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }
    }
}