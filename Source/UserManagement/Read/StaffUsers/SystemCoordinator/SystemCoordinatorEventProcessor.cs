using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

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

        public async Task Process(SystemConfiguratorRegistered @event)
        {
            await _systemCoordinators.SaveAsync(new SystemCoordinator(
                    @event.StaffUserId,
                    @event.BirthYear,
                    (Sex)@event.Sex,
                    @event.NationalSociety,
                    (Language)@event.PreferredLanguage
                    ));
        }

        //TODO: 

        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((_Role)@event.Role == _Role.SystemCoordinator)
        //        await _systemCoordinators.RemoveAsync(@event.StaffUserId);
        //}

        //public void Process(PhoneNumberRegistered @event)
        //{
        //    if ((_Role)@event.Role == _Role.SystemCoordinator)
        //    {
        //        var user = _systemCoordinators.GetById(@event.StaffUserId);
        //        user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //        _systemCoordinators.Save(user);
        //    }

        //}
        //public void Process(PhoneNumberRemovedFromStaffUser @event)
        //{
        //    if ((_Role)@event.Role == _Role.SystemCoordinator)
        //    {
        //        var user = _systemCoordinators.GetById(@event.StaffUserId);
        //        user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //        _systemCoordinators.SaveAsync(user);
        //    }
        //}
    }
}