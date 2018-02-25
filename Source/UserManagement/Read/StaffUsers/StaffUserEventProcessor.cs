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

        public async Task Process(DataConsumerAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }
        public async Task Process(AdminAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }
        public async Task Process(DataCoordinatorAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }
        public async Task Process(DataOwnerAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }
        public async Task Process(SystemCoordinatorAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }
        public async Task Process(DataVerifierAdded @event)
        {
            await _staffUserCollection.SaveAsync(new StaffUser(@event));
        }

        public async Task Process(StaffUserDeleted @event)
        {
            await _staffUserCollection.RemoveAsync(@event.StaffUserId);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            var user = await _staffUserCollection.GetByIdAsync(@event.StaffUserId);
            //TODO: Should be checked in business validator(?)
            if (user == null)
            {
                return;
            }
            user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

            await _staffUserCollection.SaveAsync(user);
        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            var user = await _staffUserCollection.GetByIdAsync(@event.StaffUserId);
            //TODO: Should be checked in business validator(?)
            if (user == null)
            {
                return;
            }
            user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            await _staffUserCollection.SaveAsync(user);
        }
    }
}
