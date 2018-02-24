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
            await _dataOwners.SaveAsync(new DataOwner
            {
                YearOfBirth = @event.YearOfBirth,
                AssignedNationalSociety = new List<Guid> { @event.AssignedNationalSociety },
                DisplayName = @event.DisplayName,
                DutyStation = @event.DutyStation,
                Email = @event.Email,
                FullName = @event.FullName,
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
                await _dataOwners.RemoveAsync(@event.Id);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataOwner)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNumberAdded
                var user = await _dataOwners.GetByIdAsync(@event.StaffUserId);
                user.MobilePhoneNumbers.Add(@event.PhoneNumber);

                await _dataOwners.SaveAsync(user);
            }

        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataOwner)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNUmberRemoved
                var user = await _dataOwners.GetByIdAsync(@event.StaffUserId);
                // TODO: Assume that the PhoneNumber exists?
                user.MobilePhoneNumbers.Remove(@event.PhoneNumber);
                await _dataOwners.SaveAsync(user);
            }
        }
    }
}