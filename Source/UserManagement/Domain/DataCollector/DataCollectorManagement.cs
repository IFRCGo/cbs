using System;
using System.Collections.Generic;
using doLittle.Domain;
using Events.DataCollector;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;
using System.Linq;

namespace Domain.DataCollector
{
    public class DataCollectorManagement : AggregateRoot
    {
        private List<string> _phoneNumbers = new List<string>();
        public DataCollectorManagement(Guid id) : base(id)
        {
        }

        #region VisibleCommands

        public void RegisterDataCollector(Guid dataCollectorId, string fullName, string displayName)
        {

        }

        public void AddDataCollector(AddDataCollector command)
        {
            Apply(new DataCollectorAdded
            {
                Id = command.DataCollectorId,

                FullName = command.FullName,
                DisplayName = command.DisplayName,
                YearOfBirth = command.YearOfBirth,
                Sex = (int)command.Sex,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = (int)command.PreferredLanguage,
                RegisteredAt = DateTimeOffset.UtcNow,
                
                LocationLongitude = command.GpsLocation.Longitude,
                LocationLatitude = command.GpsLocation.Latitude
                //TODO: Need email?
            });

            AddPhoneNumbers(command);
        }

        public void UpdateDataCollector(UpdateDataCollector command)
        {
            // Apply DataCollectorUpdated event
            Apply(new DataCollectorUpdated
            {
                DataCollectorId = command.DataCollectorId,
                DisplayName = command.DisplayName,
                Email = command.Email,
                FullName = command.FullName,
                LocationLatitude = command.GpsLocation.Latitude,
                LocationLongitude = command.GpsLocation.Longitude,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = (int)command.PreferredLanguage,
                Sex = (int)command.Sex,
                YearOfBirth = command.YearOfBirth
            });
            AddPhoneNumbers(command);
            RemovePhoneNumbers(command);
        }

        public void AddPhoneNumber(AddPhoneNumberToDataCollector command)
        {
            if(_phoneNumbers.Contains(command.PhoneNumber))
                return;  

            Apply(new PhoneNumberAddedToDataCollector(
                command.DataCollectorId, command.PhoneNumber
                ));
        }
        public void RemovePhoneNumber(RemovePhoneNumberFromDataCollector command)
        {
            if(!_phoneNumbers.Contains(command.PhoneNumber))
                return;    

            Apply(new PhoneNumberRemovedFromDataCollector( 
                command.DataCollectorId, command.PhoneNumber
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

        private void AddPhoneNumbers(AddDataCollector command)
        {
            if (command.MobilePhoneNumbers != null && command.MobilePhoneNumbers.Any())
            {
                foreach (var number in command.MobilePhoneNumbers)
                {
                    Apply(new PhoneNumberAddedToDataCollector(
                        command.DataCollectorId, number
                    ));
                }
            }
        }

        private void AddPhoneNumbers(UpdateDataCollector command)
        {
            if (command.MobilePhoneNumbersAdded != null && command.MobilePhoneNumbersAdded.Any())
            {
                foreach (var number in command.MobilePhoneNumbersAdded)
                {
                    Apply(new PhoneNumberAddedToDataCollector(
                        command.DataCollectorId, number
                    ));
                }
            }
        }

        private void RemovePhoneNumbers(UpdateDataCollector command)
        {
            if (command.MobilePhoneNumbersRemoved != null && command.MobilePhoneNumbersRemoved.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumbersRemoved)
                {
                    Apply(new PhoneNumberRemovedFromDataCollector(
                        command.DataCollectorId,
                        number
                    ));
                }
            }
        }
        #endregion
    }
}

