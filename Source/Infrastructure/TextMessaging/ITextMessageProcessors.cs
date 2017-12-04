namespace Infrastructure.TextMessaging
{

    public interface ITextMessageProcessors
    {
        bool HasProcessors { get; }
        void Process(TextMessage message);
    }
}