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
            await _dataVerifiers.Save(new DataVerifier
            {
                Age = @event.Age,
                DisplayName = @event.DisplayName,
                AssignedNationalSociety = new List<Guid>{ @event.AssignedNationalSociety },
                Email = @event.Email,
                FullName = @event.FullName,
                GeoLocation = @event.GeoLocation,
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
                await _dataVerifiers.Remove(@event.Id);
        }
    }
}