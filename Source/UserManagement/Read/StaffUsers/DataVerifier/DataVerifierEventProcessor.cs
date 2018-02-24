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

        public async Task Process(DataVerifierAdded @event)
        {
            await _dataVerifiers.SaveAsync(new DataVerifier
            {
                YearOfBirth = @event.YearOfBirth,
                DisplayName = @event.DisplayName,
                AssignedNationalSociety = new List<Guid>{ @event.AssignedNationalSociety },
                Email = @event.Email,
                FullName = @event.FullName,
                Id = @event.Id,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                MobilePhoneNumbers = new List<string> { @event.MobilePhoneNumber },
                NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                RegistrationDateTime = @event.RegistrationDate
                
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.DataVerifier)
                await _dataVerifiers.RemoveAsync(@event.Id);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataVerifier)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNumberAdded
                var user = await _dataVerifiers.GetByIdAsync(@event.StaffUserId);
                user.MobilePhoneNumbers.Add(@event.PhoneNumber);

                await _dataVerifiers.SaveAsync(user);
            }

        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role)@event.Role == Role.DataVerifier)
            {
                // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNUmberRemoved
                var user = await _dataVerifiers.GetByIdAsync(@event.StaffUserId);
                // TODO: Assume that the PhoneNumber exists?
                user.MobilePhoneNumbers.Remove(@event.PhoneNumber);
                await _dataVerifiers.SaveAsync(user);
            }
        }
    }
}