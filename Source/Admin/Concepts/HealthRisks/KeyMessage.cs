using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class KeyMessage : Value<KeyMessage>
    {
        public KeyMessageId Id { get; set; }
        public string Message { get; set; }

        public Language Language { get; set; }
    }
}