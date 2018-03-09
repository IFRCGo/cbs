using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Domain;
using Domain.DataCollector.Registering;
using Events.DataCollector;

namespace Domain.DataCollector
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
            int yearOfBirth, Sex sex, Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, IEnumerable<string> phoneNumbers,
            DateTimeOffset registeredAt
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
                nationalSociety,
                (int)preferredLanguage,
                gpsLocation.Longitude,
                gpsLocation.Latitude,
                registeredAt
            ));

            AddPhoneNumbers(phoneNumbers);
        }

        public void UpdateDataCollector(
            string fullName, string displayName,
            Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, IEnumerable<string> phoneNumbersAdded,
            IEnumerable<string> phoneNumbersRemoved
            )
        {
            Apply(new DataCollectorUpdated
            (
                EventSourceId,
                fullName,
                displayName,
                nationalSociety,
                (int)preferredLanguage,
                gpsLocation.Longitude,
                gpsLocation.Latitude
            ));
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

