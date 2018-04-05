using Dolittle.Serialization.Json;

namespace Infrastructure.TextMessaging
{
    public interface ITextMessageListener
    {
        void Start();
    }
}