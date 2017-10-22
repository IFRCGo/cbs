namespace Infrastructure.TextMessaging
{

    public interface ITextMessageProcessors
    {
        void Process(TextMessage message);
    }
}