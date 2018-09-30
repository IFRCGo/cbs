using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.Domain;
using Events.DataCollector;

namespace Domain.DataCollectors
{
    public class DataCollector : AggregateRoot
    {
        public DataCollector(Guid id) : base(id)
        {
        }

        public void RegisterDataCollector(
            string fullName, string displayName,
            int yearOfBirth, Sex sex, Language preferredLanguage,
            Location gpsLocation, IEnumerable<string> phoneNumbers, DateTimeOffset registeredAt,
            string region, string district
            )
        {
            Apply(new DataCollectorRegistered
            (
                EventSourceId,
                fullName,
                displayName,
                yearOfBirth,
                (int)sex,
                (int)preferredLanguage,
                gpsLocation.Longitude,
                gpsLocation.Latitude,
                registeredAt,
                region,
                district
            ));

            foreach (var phoneNumber in phoneNumbers)
            {
                AddPhoneNumber(phoneNumber);
            }

            BeginTraining();
        }

        public void ChangeLocation(Location location)
        {
            //if (!_isRegistered) //TODO: State is not persisted at the moment it seems
            //{
            //    throw new Exception("Datacollector not registered");
            //}

            Apply(new DataCollectorLocationChanged(EventSourceId, location.Latitude, location.Longitude));
        }

        public void ChangePreferredLanguage(Language language)
        {
            //if (!_isRegistered) //TODO: State is not persisted at the moment it seems
            //{
            //    throw new Exception("Datacollector not registered");
            //}

            Apply(new DataCollectorPreferredLanguageChanged(EventSourceId, (int)language));
        }

        public void BeginTraining()
        {
            Apply(new DataCollectorBeganTraining(EventSourceId));
        }

        public void EndTraining()
        {
            Apply(new DataCollectorCompletedTraining(EventSourceId));
        }

        public void ChangeBaseInformation(string fullName, string displayName, int yearOfBirth, Sex sex, string region, string district)
        {
            //if (!_isRegistered) //TODO: State is not persisted at the moment it seems
            //{
            //    throw new Exception("Datacollector not registered");
            //}

            Apply(new DataCollectorUserInformationChanged(EventSourceId, fullName, displayName, yearOfBirth, (int)sex, region, district));
        }

        public void DeleteDataCollector()
        {
            Apply(new DataCollectorRemoved(
                EventSourceId
            ));
        }

        public void ChangeVillage(string village)
        {
            Apply(new DataCollectorVillageChanged(EventSourceId, village));
        }

        public void AddPhoneNumber(string number)
        {
            
            Apply(new PhoneNumberAddedToDataCollector(
                EventSourceId,
                number));

        }

        public void RemovePhoneNumbers(string number)
        {
            Apply(new PhoneNumberRemovedFromDataCollector(
                EventSourceId,
                number
            ));
        }
    }
}

