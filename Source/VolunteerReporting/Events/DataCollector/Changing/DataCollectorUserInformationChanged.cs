using System;
using Dolittle.Events;

namespace Events.DataCollectors.Changing
{
    public class DataCollectorUserInformationChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }

        public int YearOfBirth { get; }
        public int Sex { get; }

        public string Region { get; }
        public string District { get; }

        public DataCollectorUserInformationChanged(Guid dataCollectorId, string fullName, string displayName, int yearOfBirth, int sex, string region, string district)
        {
            DataCollectorId = dataCollectorId;
            FullName = fullName;
            DisplayName = displayName;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            Region = region;
            District = district;
        }
    }
}