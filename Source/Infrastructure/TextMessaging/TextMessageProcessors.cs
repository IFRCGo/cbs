using System.Linq;
using doLittle.Collections;
using doLittle.Types;

namespace Infrastructure.TextMessaging
{
    public class TextMessageProcessors : ITextMessageProcessors
    {
        readonly IInstancesOf<ICanProcessTextMessage> _processors;
        public bool HasProcessors => _processors?.Any() ?? false;

        public TextMessageProcessors(IInstancesOf<ICanProcessTextMessage> processors)
        {
            _processors = processors;
        }


        public void Process(TextMessage message)
        {
            _processors.ForEach(processor => processor.Process(message));
        }
    }
}