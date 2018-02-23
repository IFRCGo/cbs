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
            await _dataCoordinators.Save(new DataCoordinator
            {
                Age = @event.Age,
                AssignedNationalSociety = new List<Guid> { @event.AssignedNationalSociety},
                DisplayName = @event.DisplayName,
                Email = @event.Email,
                FullName = @event.FullName,
                GeoLocation = @event.GeoLocation,
                Id = @event.Id,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                MobilePhoneNumbers = new List<string> { @event.MobilePhoneNumber},
                NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex,
                PreferredLanguage = (Language)@event.PreferredLanguage
                
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
                await _dataCoordinators.Remove(@event.Id);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNumberAdded
                var user = await _dataCoordinators.GetByIdAsync(@event.StaffUserId);
                user.MobilePhoneNumbers.Add(@event.PhoneNumber);

                await _dataCoordinators.Save(user);
            }

        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataCoordinator)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNUmberRemoved
                var user = await _dataCoordinators.GetByIdAsync(@event.StaffUserId);
                // TODO: Assume that the PhoneNumber exists?
                user.MobilePhoneNumbers.Remove(@event.PhoneNumber);
                await _dataCoordinators.Save(user);
            }
        }
    }
}