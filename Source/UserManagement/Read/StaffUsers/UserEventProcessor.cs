using doLittle.Events.Processing;
using Events.StaffUser.Registration;
using Read.StaffUsers.Models;
namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private IStaffUsers _collection;

        public UserEventProcessor(IStaffUsers collection)
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
            //_collection.Save(new DataConsumer(
            //    eve
            //    ));
        }
    }
}