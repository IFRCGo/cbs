using doLittle.Events.Processing;
using Events.StaffUser.Registration;

namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private IStaffUsersForReading _collection;

        public UserEventProcessor(IStaffUsersForReading collection)
        {
            _collection = collection;
        }

        public void Process(NewUserRegistered @event)
        {
            _collection.Save(new Admin (
                    @event.StaffUserId,
                    @event.FullName,
                    @event.DisplayName,
                    @event.Email,
                    @event.RegisteredAt
                ));
        }

        public void Process(StaffDataConsumerRegistered @event)
        {
            _collection.Save(new DataConsumer());
        }
    }
}