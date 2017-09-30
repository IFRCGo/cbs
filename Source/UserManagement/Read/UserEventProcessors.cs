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

        public void Process(StaffUserAdded @event)
        {
            var user = new StaffUser(@event);

            _users.Save(user);
        }

        public void Process(VolunteerUserAdded @event)
        {
            var user = new VolunteerUser
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                LastName = @event.LastName
            };

            _users.Save(user);
        }
    }
}