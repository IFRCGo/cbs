namespace Read
{
    public class UserEventProcessors : Infrastructure.Events.IEventProcessor
    {
        readonly IUsers _users;

        public UserEventProcessors(IUsers users)
        {
            _users = users;
        }
    }
}