using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers.DataOwner
{
    public class DataOwnerEventProcessor : ICanProcessEvents
    {
        private readonly IDataOwners _dataOwners;

        public DataOwnerEventProcessor(
            IDataOwners dataOwners
        )
        {
            _dataOwners = dataOwners;
        }

        public async Task Process(DataOwnerAdded @event)
        {
            await _dataOwners.Save(new DataOwner
            {
                Age = @event.Age,
                AssignedNationalSociety = new List<Guid> { @event.AssignedNationalSociety },
                DisplayName = @event.DisplayName,
                DutyStation = @event.DutyStation,
                Email = @event.Email,
                FullName = @event.FullName,
                GeoLocation = @event.GeoLocation,
                Id = @event.Id,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                MobilePhoneNumbers = new List<string> { @event.MobilePhoneNumber },
                Sex = (Sex)@event.Sex,
                NationalSociety = @event.NationalSociety,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                Position = @event.Position
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.DataOwner)
                await _dataOwners.Remove(@event.Id);
        }
    }
}