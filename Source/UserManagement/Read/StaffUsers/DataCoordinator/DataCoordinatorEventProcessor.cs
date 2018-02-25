using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers.DataCoordinator
{
    public class DataCoordinatorEventProcessor : ICanProcessEvents
    {
        private readonly IDataCoordinators _dataCoordinators;

        public DataCoordinatorEventProcessor(
            IDataCoordinators dataCoordinators
        )
        {
            _dataCoordinators = dataCoordinators;
        }

        public async Task Process(DataCoordinatorAdded @event)
        {
            await _dataCoordinators.SaveAsync(new DataCoordinator
            {
                YearOfBirth = @event.YearOfBirth,
                AssignedNationalSocieties = new List<Guid>(),
                DisplayName = @event.DisplayName,
                Email = @event.Email,
                FullName = @event.FullName,
                Id = @event.StaffUserId,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                MobilePhoneNumbers = new List<PhoneNumber>(),
                NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex,
                PreferredLanguage = (Language)@event.PreferredLanguage
                
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
                await _dataCoordinators.RemoveAsync(@event.StaffUserId);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
            {
                var user = await _dataCoordinators.GetByIdAsync(@event.StaffUserId);
                //TODO: Should be checked in business validator(?)
                if (user == null)
                {
                    return;
                }
                user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

                await _dataCoordinators.SaveAsync(user);
            }

        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
            {
                var user = await _dataCoordinators.GetByIdAsync(@event.StaffUserId);
                //TODO: Should be checked in business validator(?)
                if (user == null)
                {
                    return;
                }
                user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
                await _dataCoordinators.SaveAsync(user);
            }
        }
    }
}