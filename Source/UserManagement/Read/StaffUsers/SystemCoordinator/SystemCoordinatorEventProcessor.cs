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
                Age = @event.Age,
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
    }
}