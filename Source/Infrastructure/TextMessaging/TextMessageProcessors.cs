using doLittle.Collections;
using doLittle.Types;

namespace Infrastructure.TextMessaging
{
    public class TextMessageProcessors : ITextMessageProcessors
    {
        readonly IInstancesOf<ICanProcessTextMessage> _processors;
        public TextMessageProcessors(IInstancesOf<ICanProcessTextMessage> processors, int blah)
        {
            _processors = processors;
        }

        public void Process(TextMessage message)
        {
            _processors.ForEach(processor => processor.Process(message));
        }
    }
}