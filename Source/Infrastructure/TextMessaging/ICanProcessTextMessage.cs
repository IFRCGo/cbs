namespace Infrastructure.TextMessaging
{

    public interface ICanProcessTextMessage
    {
        void Process(TextMessage message);
    }
}