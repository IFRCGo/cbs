using System.Linq;
using doLittle.Collections;
using doLittle.DependencyInversion;
using doLittle.Types;

namespace Infrastructure.TextMessaging
{
    public class TextMessageProcessors : ITextMessageProcessors
    {
        readonly IInstancesOf<ICanProcessTextMessage> _processors;

        public TextMessageProcessors(IInstancesOf<ICanProcessTextMessage> processors)
        {
            _processors = processors;
        }

        public bool HasProcessors => _processors?.Any() ?? false;

        public void Process(TextMessage message)
        {
            _processors.ForEach(processor => processor.Process(message));
        }
    }
}