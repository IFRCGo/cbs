using System.Threading.Tasks;
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
            await _staffUserCollection.Save(new StaffUser(@event));
        }
        public async Task Process(AdminAdded @event)
        {
            await _staffUserCollection.Save(new StaffUser(@event));
        }
        public async Task Process(DataCoordinatorAdded @event)
        {
            await _staffUserCollection.Save(new StaffUser(@event));
        }
        public async Task Process(DataOwnerAdded @event)
        {
            await _staffUserCollection.Save(new StaffUser(@event));
        }
        public async Task Process(SystemCoordinatorAdded @event)
        {
            await _staffUserCollection.Save(new StaffUser(@event));
        }
        public async Task Process(DataVerifierAdded @event)
        {
            await _staffUserCollection.Save(new StaffUser(@event));
        }

        public async Task Process(StaffUserDeleted @event)
        {
            await _staffUserCollection.Remove(@event.Id);
        }

        public async Task Process(PhoneNumberAddedToStaffUser @event)
        {
            // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNumberAdded
            var user = await _staffUserCollection.GetByIdAsync(@event.StaffUserId);
            user.MobilePhoneNumbers.Add(@event.PhoneNumber);

            await _staffUserCollection.Save(user);
        }
        public async Task Process(PhoneNumberRemovedFromStaffUser @event)
        {
            // TODO: Assume that the StaffUser exists here? Should be checked in the BusinessValidator of PhoneNUmberRemoved
            var user = await _staffUserCollection.GetByIdAsync(@event.StaffUserId);
            // TODO: Assume that the PhoneNumber exists?
            user.MobilePhoneNumbers.Remove(@event.PhoneNumber);
            await _staffUserCollection.Save(user);
        }
    }
}
