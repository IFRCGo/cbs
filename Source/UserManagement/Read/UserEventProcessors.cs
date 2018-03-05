using Events;
using doLittle.Events.Processing;

namespace Read
{
    public class UserEventProcessors : ICanProcessEvents
    {
        readonly IUsers _users;

        public UserEventProcessors(IUsers users)
        {
            _users = users;
        }

        public void Process(StaffUserAdded @event)
        {
            var user = new StaffUser(@event);

            _users.Save(user);
        }        

        public void Process(UserDeleted @event)
        {
            _users.DeleteUserById(@event.Id);
        }
    }
}