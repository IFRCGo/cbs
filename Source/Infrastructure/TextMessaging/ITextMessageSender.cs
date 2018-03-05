namespace Infrastructure.TextMessaging
{
    public interface ITextMessageSender
    {
        void Send(OutgoingTextMessage message);
    }
}