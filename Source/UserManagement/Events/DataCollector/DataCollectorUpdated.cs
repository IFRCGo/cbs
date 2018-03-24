using System;
using doLittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorUpdated : IEvent
    {
        public Guid DataCollectorId { get; }

        public string FullName { get; }
        public string DisplayName { get; }
        public Guid NationalSociety { get; }
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }

        public DataCollectorUpdated(Guid dataCollectorId, string fullName, string displayName, 
            Guid nationalSociety, int preferredLanguage, double locationLongitude, double locationLatitude)
        {
            DataCollectorId = dataCollectorId;
            FullName = fullName;
            DisplayName = displayName;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
        }
    }
}