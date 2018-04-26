using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorRegistered : IEvent
    {
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public int YearOfBirth { get; }
        public int Sex { get; }
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }
        public DateTimeOffset RegisteredAt { get; }

        public DataCollectorRegistered(
            Guid dataCollectorId,
            string fullName,
            string displayName,            
            int yearOfBirth,
            int sex,
            int preferredLanguage,
            double locationLongitude, 
            double locationLatitude,
            DateTimeOffset registeredAt)
        {
            DataCollectorId = dataCollectorId;
            FullName = fullName;
            DisplayName = displayName;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
            RegisteredAt = registeredAt;
        }
    }
}