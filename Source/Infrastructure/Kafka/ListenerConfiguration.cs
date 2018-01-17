namespace Kafka
{
    public class ListenerConfiguration
    {
        public ListenerConfiguration(Topic topic)
        {
            Topic = topic;

        }

        public Topic Topic { get; }
    }
}