using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

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

        public async Task Process(DataOwnerRegistered @event)
        {
            await _dataOwners.SaveAsync(new DataOwner(
                    @event.StaffUserId,
                    @event.BirthYear,
                    (Sex)@event.Sex,
                    @event.NationalSociety,
                    (Language)@event.PreferredLanguage,
                    new Location(@event.Latitude, @event.Longitude),
                    @event.Position,
                    @event.DutyStation
                    ));
        }

        //TODO: Update to the new system
        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((Role)@event.Role == Role.DataOwner)
        //        await _dataOwners.RemoveAsync(@event.StaffUserId);
        //}

        //public void Process(PhoneNumberAddedToStaffUser @event)
        //{
        //    if ((Role) @event.Role != Role.DataOwner)
        //    {
        //        return;
        //    }
        //    var user = _dataOwners.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //    _dataOwners.SaveAsync(user);

        //}
        //public void Process(PhoneNumberRemovedFromStaffUser @event)
        //{
        //    if ((Role) @event.Role != Role.DataOwner)
        //    {
        //        return;
        //    }
        //    var user = _dataOwners.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //    _dataOwners.SaveAsync(user);
        //}
    }
}