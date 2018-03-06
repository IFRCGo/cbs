using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

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
        
        public async Task Process(DataCoordinatorRegistered @event)
        {
            await _dataCoordinators.SaveAsync(new DataCoordinator(
                    @event.StaffUserId,
                    @event.BirthYear,
                    (Sex)@event.Sex,
                    @event.NationalSociety,
                    (Language)@event.PreferredLanguage
                    ));
        }

        //TODO: Update to the new system
        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((Role)@event.Role == Role.DataCoordinator)
        //        await _dataCoordinators.RemoveAsync(@event.StaffUserId);
        //}

        //public void Process(PhoneNumberAddedToStaffUser @event)
        //{
        //    if ((Role) @event.Role != Role.DataCoordinator)
        //    {
        //        return;
        //    }

        //    var user = _dataCoordinators.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //    _dataCoordinators.Save(user);

        //}
        //public void Process(PhoneNumberRemovedFromStaffUser @event)<
        //    var user = _dataCoordinators.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //    _dataCoordinators.Save(user);
        //}
    }
}