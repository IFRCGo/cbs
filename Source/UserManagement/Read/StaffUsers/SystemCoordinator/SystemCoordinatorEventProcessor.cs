using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers.SystemCoordinator
{
    public class SystemCoordinatorEventProcessor : ICanProcessEvents
    {
        private readonly ISystemCoordinators _systemCoordinators;

        public SystemCoordinatorEventProcessor (
            ISystemCoordinators systemCoordinators
        )
        {
            _systemCoordinators = systemCoordinators;
        }

        public async Task Process(SystemCoordinatorAdded @event)
        {
            await _systemCoordinators.Save(new SystemCoordinator
            {
                YearOfBirth = @event.YearOfBirth,
                DisplayName = @event.DisplayName,
                AssignedNationalSociety = new List<Guid> { @event.AssignedNationalSociety },
                Email = @event.Email,
                FullName = @event.FullName,
                GeoLocation = @event.GeoLocation,
                Id = @event.Id,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                MobilePhoneNumbers = new List<string> { @event.MobilePhoneNumber },
                NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex,
                PreferredLanguage = (Language)@event.PreferredLanguage

            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.SystemCoordinator)
                await _systemCoordinators.Remove(@event.Id);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role) @event.Role == Role.SystemCoordinator)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNumberAdded
                var user = await _systemCoordinators.GetByIdAsync(@event.StaffUserId);
                user.MobilePhoneNumbers.Add(@event.PhoneNumber);

                await _systemCoordinators.Save(user);
            }
            
        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role) @event.Role == Role.SystemCoordinator)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNUmberRemoved
                var user = await _systemCoordinators.GetByIdAsync(@event.StaffUserId);
                // TODO: Assume that the PhoneNumber exists?
                user.MobilePhoneNumbers.Remove(@event.PhoneNumber);
                await _systemCoordinators.Save(user);
            }
        }
    }
}