using Events;

namespace Read
{
    public class UserEventProcessors : Infrastructure.Events.IEventProcessor
    {
        readonly IUsers _users;

        public UserEventProcessors(IUsers users)
        {
            _users = users;
        }

        public void Process(UserAdded @event)
        {
            var user = new User
            {
                Name = @event.Name,
                Id = @event.Id
            };

            _users.Save(user);
        }
    }
}