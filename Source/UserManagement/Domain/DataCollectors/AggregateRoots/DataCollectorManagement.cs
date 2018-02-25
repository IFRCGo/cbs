using System;
using doLittle.Domain;
using Domain.DataCollectors.Commands;
using Events.DataCollector;

namespace Domain.DataCollectors.AggregateRoots
{
    public class DataCollectorManagement : AggregateRoot
    {

        public DataCollectorManagement(Guid id) : base(id)
        {
        }

        public void AddDataCollector(AddDataCollector command)
        {
            // TODO: All events should have a constructor since all of its fields should be
            // immutable
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

            if (command.MobilePhoneNumbers != null && command.MobilePhoneNumbers.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumbers)
                {
                    Apply(new PhoneNumberAddedToDataCollector(
                        command.DataCollectorId, number
                    ));
                }
            }
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
            // Check if PhoneNumbersAdded list is not null and not empty
            if (command.MobilePhoneNumbersAdded != null && command.MobilePhoneNumbersAdded.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumbersAdded)
                {
                    Apply(new PhoneNumberAddedToDataCollector(
                        command.DataCollectorId,
                        number
                        ));
                }
            }
            // Check if PhoneNumbersRemoved list is not null and not empty
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

        public void AddPhoneNumber(AddPhoneNumberToDataCollector command)
        {
            Apply(new PhoneNumberAddedToDataCollector(
                command.DataCollectorId, command.PhoneNumber
                ));
        }
        public void RemovePhoneNumber(RemovePhoneNumberFromDataCollector command)
        {
            Apply(new PhoneNumberRemovedFromDataCollector( 
                command.DataCollectorId, command.PhoneNumber
            ));
        }

        
    }
}

