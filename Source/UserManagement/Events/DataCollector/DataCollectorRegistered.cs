using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorRegistered : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public int Sex { get; set; }
        public int PreferredLanguage { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

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