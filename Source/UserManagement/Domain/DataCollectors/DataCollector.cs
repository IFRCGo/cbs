using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Domain;
using Events.DataCollector;

namespace Domain.DataCollectors
{
    public class DataCollector : AggregateRoot
    {
        public Guid Id { get; private set; }

        public DataCollector(Guid id) : base(id)
        {
            Id = id;

        }

        public void AddDataCollector(AddDataCollector command)
        {
            // TODO: All events should have a constructor since all of its fields should be
            // immutable
            Apply(new DataCollectorAdded
            {
                Id = this.Id,//Id = command.Id,
                FullName = command.FullName,
                DisplayName = command.DisplayName,
                YearOfBirth = command.YearOfBirth,
                Sex = (int)command.Sex,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = (int)command.PreferredLanguage,
                RegisteredAt = DateTimeOffset.UtcNow

                //MobilePhoneNumber = command.MobilePhoneNumber,
                //Email = command.Email
            });
        }

        //TODO: Add business validation that checks if number is already added
        public void AddPhoneNumber(string phoneNumber)
        {
            Apply(new PhoneNumberAddedToDataCollector
            {
                Id = Guid.NewGuid(),
                DataCollectorId = EventSourceId,
                PhoneNumber = phoneNumber
            });
        }

        public void RemovePhoneNumber(string phoneNumber)
        {
            Apply(new PhoneNumberRemovedFromDataCollector
            {
                Id = Guid.NewGuid(),
                DataCollectorId = EventSourceId,
                PhoneNumber = phoneNumber
            });
        }
    }
}

