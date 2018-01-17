using doLittle.Concepts;

namespace Kafka
{
    public class Topic : ConceptAs<string>
    {
        public static implicit operator Topic(string topic)
        {
            return new Topic { Value = topic };
        }
    }
}