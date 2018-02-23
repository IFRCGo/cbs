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
    }
}
