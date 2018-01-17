using doLittle.Concepts;

namespace Kafka
{
    public class KafkaConnectionString : ConceptAs<string>
    {
        public static implicit operator KafkaConnectionString(string connectionString)
        {
            return new KafkaConnectionString { Value = connectionString };
        }
    }
}