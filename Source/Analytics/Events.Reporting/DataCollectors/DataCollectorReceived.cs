using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    public class DataCollectorReceived : IEvent
    {
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public int YearOfBirth { get; }
        public int Sex { get; }
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }

        public string Region { get; }
        public string District { get; }
        public DateTimeOffset RegisteredAt { get; }

        public DataCollectorReceived(
            Guid dataCollectorId,
            string fullName,
            string displayName,
            int yearOfBirth,
            int sex,
            int preferredLanguage,
            double locationLongitude,
            double locationLatitude,
            DateTimeOffset registeredAt,
            string region,
            string district)
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
            Region = region;
            District = district;
        }
    }
}
