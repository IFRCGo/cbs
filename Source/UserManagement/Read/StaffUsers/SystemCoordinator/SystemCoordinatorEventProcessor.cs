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
            await _systemCoordinators.SaveAsync(new SystemCoordinator
            {
                YearOfBirth = @event.YearOfBirth,
                DisplayName = @event.DisplayName,
                AssignedNationalSociety = new List<Guid>(),
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
            if ((_Role)@event.Role == _Role.SystemCoordinator)
                await _systemCoordinators.RemoveAsync(@event.StaffUserId);
        }

        public void Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((_Role) @event.Role == _Role.SystemCoordinator)
            {
                var user = _systemCoordinators.GetById(@event.StaffUserId);
                //TODO: Should be checked in business validator(?)
                if (user == null)
                {
                    return;
                }
                user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

                _systemCoordinators.Save(user);
            }
            
        }
        public void Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((_Role) @event.Role == _Role.SystemCoordinator)
            {
                var user = _systemCoordinators.GetById(@event.StaffUserId);
                //TODO: Should be checked in business validator(?)
                if (user == null)
                {
                    return;
                }
                user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
                _systemCoordinators.SaveAsync(user);
            }
        }
    }
}