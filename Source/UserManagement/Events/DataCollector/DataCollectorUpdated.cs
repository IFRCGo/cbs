using System;
using doLittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorUpdated : IEvent
    {
        public Guid DataCollectorId { get; }

        public string FullName { get; }
        public string DisplayName { get; }
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }

        public DataCollectorUpdated(
            Guid dataCollectorId,
            string fullName,
            string displayName,
            int preferredLanguage,
            double locationLongitude,
            double locationLatitude)
        {
            DataCollectorId = dataCollectorId;
            FullName = fullName;
            DisplayName = displayName;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
        }
    }
}