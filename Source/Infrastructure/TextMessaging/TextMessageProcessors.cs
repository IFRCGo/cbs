using System.Collections.Generic;
using System.Linq;
using doLittle.Collections;
using doLittle.DependencyInversion;
using doLittle.Runtime.Commands;
using doLittle.Runtime.Transactions;
using doLittle.Types;

namespace Infrastructure.TextMessaging
{
    public class TextMessageProcessors : ITextMessageProcessors
    {
        readonly IInstancesOf<ICanProcessTextMessage> _processors;
        readonly ICommandContextManager _commandContextManager;

        public TextMessageProcessors(
            IInstancesOf<ICanProcessTextMessage> processors,
            ICommandContextManager commandContextManager)
        {
            _processors = processors;
            _commandContextManager = commandContextManager;
        }

        public bool HasProcessors => _processors?.Any() ?? false;

        public void Process(TextMessage message)
        {
            var commandContext = _commandContextManager.EstablishForCommand(
                new CommandRequest(
                    TransactionCorrelationId.New(), 
                    null,
                    new Dictionary<string, object>())
                );
            
            _processors.ForEach(processor => processor.Process(message));

            commandContext.Commit();
        }
    }
}