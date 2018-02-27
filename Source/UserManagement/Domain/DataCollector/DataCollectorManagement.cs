using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Domain;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;
using Events.DataCollector;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;
using System.Linq;

namespace Domain.DataCollector
{
    public class DataCollectorManagement : AggregateRoot
    {
        private readonly List<string> _numbers;
        public DataCollectorManagement(Guid id) : base(id)
        {
            _numbers = new List<string>();
        }

        #region VisibleCommands

<<<<<<< HEAD
        public void RegisterDataCollector(
            Guid dataCollectorId, string fullName, string displayName,
            int yearOfBirth, Sex sex, Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, string email, List<string> phoneNumbers
            )
=======
        public void RegisterDataCollector(Guid dataCollectorId, string fullName, string displayName)
        {

        }

        public void AddDataCollector(AddDataCollector command)
>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
        {
            Apply(new DataCollectorAdded
            {
                DataCollectorId = dataCollectorId,

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
            Guid dataCollectorId, string fullName, string displayName,
            Guid nationalSociety, Language preferredLanguage,
            Location gpsLocation, string email, List<string> phoneNumbersAdded,
            List<string> phoneNumbersRemoved
            )
        {
            // Apply DataCollectorUpdated event
            Apply(new DataCollectorUpdated
            {
                DataCollectorId = dataCollectorId,
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
<<<<<<< HEAD
            if (_numbers.Contains(number)) return;
            
=======
            if(_phoneNumbers.Contains(command.PhoneNumber))
                return;  

>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
            Apply(new PhoneNumberAddedToDataCollector(
                EventSourceId,
                number
            ));
        }
        public void RemovePhoneNumber(string number)
        {
<<<<<<< HEAD
            if (!_numbers.Contains(number)) return;
            

            Apply(new PhoneNumberRemovedFromDataCollector(
                EventSourceId,
                number
=======
            if(!_phoneNumbers.Contains(command.PhoneNumber))
                return;    

            Apply(new PhoneNumberRemovedFromDataCollector( 
                command.DataCollectorId, command.PhoneNumber
>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
            ));
        }

        private void On(PhoneNumberAddedToDataCollector @event)
        {
            _phoneNumbers.Add(@event.PhoneNumber);
        }

        private void On(PhoneNumberRemovedFromDataCollector @event)
        {
            _phoneNumbers.Remove(@event.PhoneNumber);
        }    


        #endregion

        #region PhoneNumber

        private void AddPhoneNumbers(IReadOnlyCollection<string> numbers)
        {
<<<<<<< HEAD
            if (numbers == null || numbers.Count <= 0) return;
            foreach (var number in numbers)
=======
            if (command.MobilePhoneNumbers != null && command.MobilePhoneNumbers.Any())
>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
            {
                Apply(new PhoneNumberAddedToDataCollector(
                    EventSourceId, 
                    number
                ));
            }
        }

        private void RemovePhoneNumbers(IReadOnlyCollection<string> numbers)
        {
<<<<<<< HEAD
            if (numbers == null || numbers.Count <= 0) return;
            foreach (var number in numbers)
=======
            if (command.MobilePhoneNumbersAdded != null && command.MobilePhoneNumbersAdded.Any())
>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
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

