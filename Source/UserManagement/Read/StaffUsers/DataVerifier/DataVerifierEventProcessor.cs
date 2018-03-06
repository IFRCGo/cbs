using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

namespace Read.StaffUsers.DataVerifier
{
    public class DataVerifierEventProcessor : ICanProcessEvents
    {
        
        private readonly IDataVerifiers _dataVerifiers;

        public DataVerifierEventProcessor(
            IDataVerifiers dataVerifiers
        )
        {
            _dataVerifiers = dataVerifiers;
        }

        public async Task Process(StaffDataVerifierRegistered @event)
        {
            await _dataVerifiers.SaveAsync(new DataVerifier(
                    @event.StaffUserId,
                    @event.BirthYear,
                    (Sex)@event.Sex,
                    @event.NationalSociety,
                    (Language)@event.PreferredLanguage,
                    new Location(@event.Latitude, @event.Longitude)
                    ));
        }

        //TODO: Update to the new system
        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((Role)@event.Role == Role.DataVerifier)
        //        await _dataVerifiers.RemoveAsync(@event.StaffUserId);
        //}

        //public void Process(PhoneNumberAddedToStaffUser @event)
        //{
        //    if ((Role)@event.Role == Role.DataVerifier)
        //    {
        //        var user = _dataVerifiers.GetById(@event.StaffUserId);
        //        user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //        _dataVerifiers.Save(user);
        //    }

        //}
        //public void Process(PhoneNumberRemovedFromStaffUser @event)
        //{
        //    if ((Role)@event.Role == Role.DataVerifier)
        //    {
        //        var user = _dataVerifiers.GetById(@event.StaffUserId);
        //        user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //        _dataVerifiers.Save(user);
        //    }
        //}
    }
}