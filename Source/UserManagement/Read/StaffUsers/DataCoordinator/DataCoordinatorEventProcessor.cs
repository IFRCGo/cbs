using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

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

        public void Process(DataCoordinatorAdded @event)
        {
            _dataCoordinators.Save(new DataCoordinator
            {
                YearOfBirth = @event.YearOfBirth,
                AssignedNationalSocieties = new List<Guid>(),
                DisplayName = @event.DisplayName,
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
            if ((Role)@event.Role == Role.DataCoordinator)
                await _dataCoordinators.RemoveAsync(@event.StaffUserId);
        }

        public void Process(PhoneNumberAddedToStaffUser @event)
        {
            if ((Role) @event.Role != Role.DataCoordinator)
            {
                return;
            }

            var user = _dataCoordinators.GetById(@event.StaffUserId);
            //TODO: Should be checked in business validator(?)
            if (user == null)
            {
                return;
            }
            user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

            _dataCoordinators.Save(user);

        }
        public void Process(PhoneNumberRemovedFromStaffUser @event)
        {
            if ((Role) @event.Role != Role.DataCoordinator)
            {
                return;
            }
            var user = _dataCoordinators.GetById(@event.StaffUserId);
            //TODO: Should be checked in business validator(?)
            if (user == null)
            {
                return;
            }
            user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            _dataCoordinators.Save(user);
        }
    }
}