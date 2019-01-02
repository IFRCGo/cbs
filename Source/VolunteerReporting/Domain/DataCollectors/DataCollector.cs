/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.DataCollector;
using Dolittle.Domain;
using Domain.DataCollectors.Registration;
using Events.DataCollectors.Changing;
using Events.DataCollectors.PhoneNumber;
using Events.DataCollectors.Registration;

namespace Domain.DataCollectors
{
    public class DataCollector : AggregateRoot
    {
        private readonly List<string> _numbers = new List<string>();
        private bool _isRegistered;

        public DataCollector(Guid id) : base(id)
        {
        }

        #region VisibleCommands

        public void RegisterDataCollector(
            string fullName, string displayName,
            int yearOfBirth, Sex sex, Language preferredLanguage,
            Location gpsLocation, IEnumerable<string> phoneNumbers, DateTimeOffset registeredAt,
            string region, string district
            )
        {
            if (_isRegistered)
            {
                throw new DataCollectorAlreadyRegistered($"DataCollector '{EventSourceId} {fullName} {displayName} is already registered'");
            }

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

        #endregion

        #region On-methods

        private void On(DataCollectorRegistered @event)
        {
            _isRegistered = true;
        }

        private void On(PhoneNumberAddedToDataCollector @event)
        {
            _numbers.Add(@event.PhoneNumber);
        }

        private void On(PhoneNumberRemovedFromDataCollector @event)
        {
            _numbers.Remove(@event.PhoneNumber);
        }

        #endregion        
    }
}

