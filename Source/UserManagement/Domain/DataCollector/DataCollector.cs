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
            bool isNewRegistration,
            string fullName, string displayName,
            int yearOfBirth, Sex sex, Language preferredLanguage,
            Location gpsLocation, IEnumerable<string> phoneNumbers, DateTimeOffset registeredAt
            )
        {
            if (isNewRegistration && _isRegistered)
            {
                //TODO: We might want to Apply an event here that signals that a new data collector has been registered
                throw new DataCollectorAlreadyRegistered($"DataCollector '{EventSourceId} {fullName} {displayName} is already registered'");
            }
            //TODO: For the moment it does not seem that we can persist state for AggregateRoots for some reason?
            // Therefore this must be commented out, the result of this is that the data collector get's a new registered at value for each time it's modified...
            //if (isNewRegistration)
               // _registeredAt = DateTimeOffset.UtcNow;

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
                registeredAt
            ));

            AddPhoneNumbers(phoneNumbers);
        }

        public void DeleteDataCollector(Guid dataCollectorId)
        {
            Apply(new DataCollectorRemoved(
                dataCollectorId
            ));
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

