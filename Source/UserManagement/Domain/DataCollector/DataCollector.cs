using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Domain;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;
using Events.DataCollector;

namespace Domain.DataCollector
{
    public class DataCollector : AggregateRoot
    {
        private readonly List<string> _numbers = new List<string>();

        public DataCollector(Guid id) : base(id)
        {
        }

        #region VisibleCommands

        public void RegisterDataCollector(
            string fullName, string displayName,
            int yearOfBirth, Sex sex, Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, string email, IEnumerable<string> phoneNumbers
            )
        {
            Apply(new DataCollectorAdded
            {
                DataCollectorId = EventSourceId,

                FullName = fullName,
                DisplayName = displayName,
                YearOfBirth = yearOfBirth,
                Sex = (int)sex,
                NationalSociety = nationalSociety,
                PreferredLanguage = (int)preferredLanguage,
                RegisteredAt = DateTimeOffset.UtcNow,
                
                LocationLongitude = gpsLocation.Longitude,
                LocationLatitude = gpsLocation.Latitude
                //TODO: Need email?
            });

            AddPhoneNumbers(phoneNumbers);
        }

        public void UpdateDataCollector(
            string fullName, string displayName,
            Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, string email, IEnumerable<string> phoneNumbersAdded,
            IEnumerable<string> phoneNumbersRemoved
            )
        {
            // Apply DataCollectorUpdated event
            Apply(new DataCollectorUpdated
            {
                DataCollectorId = EventSourceId,
                DisplayName = displayName,
                Email = email,
                FullName = fullName,
                LocationLatitude = gpsLocation.Latitude,
                LocationLongitude = gpsLocation.Longitude,
                NationalSociety = nationalSociety,
                PreferredLanguage = (int)preferredLanguage,
                
            });
            AddPhoneNumbers(phoneNumbersAdded);
            RemovePhoneNumbers(phoneNumbersRemoved);
        }

        public void AddPhoneNumber(string number)
        {
            if (_numbers.Contains(number)) return;
            
            Apply(new PhoneNumberAddedToDataCollector(
                EventSourceId,
                number
            ));
        }
        public void RemovePhoneNumber(string number)
        {
            if (!_numbers.Contains(number)) return;
            

            Apply(new PhoneNumberRemovedFromDataCollector(
                EventSourceId,
                number
            ));
        }

        #endregion

        #region PhoneNumber

        private void AddPhoneNumbers(IEnumerable<string> numbers)
        {
            if (numbers == null) return;
            foreach (var number in numbers)
            {
                Apply(new PhoneNumberAddedToDataCollector(
                    EventSourceId, 
                    number
                ));
            }
        }

        private void RemovePhoneNumbers(IEnumerable<string> numbers)
        {
            if (numbers == null) return;
            foreach (var number in numbers)
            {
                Apply(new PhoneNumberRemovedFromDataCollector(
                    EventSourceId,
                    number
                ));
            }
        }
        #endregion

        #region On-methods

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

