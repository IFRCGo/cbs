using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers
{
    public class StaffUserEventProcessor : ICanProcessEvents
    {
        private readonly IStaffUsers _staffUserCollection;

        public StaffUserEventProcessor(
            IStaffUsers staffUserCollection
        )
        {
            _staffUserCollection = staffUserCollection;
        }

        #region StaffUserAddedEvents

        //TODO: Update to the new system
        //public async Task Process(DataConsumerAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}
        //public async Task Process(AdminAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}
        //public async Task Process(DataCoordinatorAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}
        //public async Task Process(DataOwnerAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}
        //public async Task Process(SystemCoordinatorAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}
        //public async Task Process(DataVerifierAdded @event)
        //{
        //    await _staffUserCollection.SaveAsync(new StaffUser(@event));
        //}

        #endregion

        #region StaffUserUpdatedEvents
        //TODO: Update to the new system
        //public void Process(AdminUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);

        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    _staffUserCollection.Save(staffUser);
        //}

        //public void Process(DataConsumerUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);

        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    staffUser.Location = new Location(@event.GpsLocationLatitude, @event.GpsLocationLongitude);

        //    _staffUserCollection.Save(staffUser);
        //}

        //public void Process(DataCoordinatorUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);

        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    staffUser.Location = new Location(@event.GpsLocationLatitude, @event.GpsLocationLongitude);

        //    staffUser.NationalSociety = @event.NationalSociety;
        //    staffUser.PreferredLanguage = (Language)@event.PreferredLanguage;

        //    _staffUserCollection.Save(staffUser);
        //}

        //public void Process(DataOwnerUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);
            
        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    staffUser.Location = new Location(@event.GpsLocationLatitude, @event.GpsLocationLongitude);

        //    staffUser.NationalSociety = @event.NationalSociety;
        //    staffUser.PreferredLanguage = (Language)@event.PreferredLanguage;

        //    staffUser.Position = @event.Position;

        //    _staffUserCollection.Save(staffUser);
        //}

        //public void Process(DataVerifierUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);

        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    staffUser.Location = new Location(@event.GpsLocationLatitude, @event.GpsLocationLongitude);

        //    staffUser.NationalSociety = @event.NationalSociety;
        //    staffUser.PreferredLanguage = (Language)@event.PreferredLanguage;

        //    _staffUserCollection.Save(staffUser);
        //}

        //public void Process(SystemCoordinatorUpdated @event)
        //{
        //    var staffUser = _staffUserCollection.GetById(@event.StaffUserId);

        //    staffUser.FullName = @event.FullName;
        //    staffUser.DisplayName = @event.DisplayName;
        //    staffUser.Email = @event.Email;

        //    staffUser.Location = new Location(@event.GpsLocationLatitude, @event.GpsLocationLongitude);

        //    staffUser.NationalSociety = @event.NationalSociety;
        //    staffUser.PreferredLanguage = (Language)@event.PreferredLanguage;

        //    _staffUserCollection.Save(staffUser);
        //}

        #endregion

        public async Task Process(StaffUserDeleted @event)
        {
            await _staffUserCollection.RemoveAsync(@event.StaffUserId);
        }

        //TODO: Update to the new system
        //public void Process(PhoneNumberAddedToStaffUser @event)
        //{
        //    var user = _staffUserCollection.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //    _staffUserCollection.Save(user);
        //}

        //public void Process(PhoneNumberRemovedFromStaffUser @event)
        //{
        //    var user = _staffUserCollection.GetById(@event.StaffUserId);
        //    user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //    _staffUserCollection.Save(user);
        //}
    }
}
