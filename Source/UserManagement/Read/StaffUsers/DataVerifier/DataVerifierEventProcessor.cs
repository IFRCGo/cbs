using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

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

        //TODO: Update to the new system
        //public async Task Process(DataVerifierAdded @event)
        //{
        //    await _dataVerifiers.SaveAsync(new DataVerifier
        //    {
        //        YearOfBirth = @event.YearOfBirth,
        //        DisplayName = @event.DisplayName,
        //        AssignedNationalSociety = new List<Guid>(),
        //        Email = @event.Email,
        //        FullName = @event.FullName,
        //        Id = @event.StaffUserId,
        //        Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
        //        MobilePhoneNumbers = new List<PhoneNumber>(),
        //        NationalSociety = @event.NationalSociety,
        //        Sex = (Sex)@event.Sex,
        //        PreferredLanguage = (Language)@event.PreferredLanguage,
        //        RegistrationDateTime = @event.RegistrationDate

        //    });
        //}

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