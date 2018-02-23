using System;
using doLittle.Domain;
using Domain.DataCollectors.Commands;
using Events.DataCollector;

namespace Domain.DataCollectors.AggregateRoots
{
    public class DataCollectorManagement : AggregateRoot
    {

        protected DataCollectorManagement(Guid id) : base(id)
        {
        }

        public void AddDataCollector(AddDataCollector command)
        {
            // TODO: All events should have a constructor since all of its fields should be
            // immutable
            Apply(new DataCollectorAdded
            {
                Id = EventSourceId,//Id = command.Id,
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
    }
}

