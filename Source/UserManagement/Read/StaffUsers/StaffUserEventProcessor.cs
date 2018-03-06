using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

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
        
        public async Task Process(NewUserRegistered @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt
            ));
        }

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
