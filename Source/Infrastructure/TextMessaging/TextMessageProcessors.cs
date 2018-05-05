using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Collections;
using Dolittle.Logging;
using Dolittle.Runtime.Commands;
using Dolittle.Runtime.Commands.Coordination;
using Dolittle.Runtime.Transactions;
using Dolittle.Types;

namespace Infrastructure.TextMessaging
{
    public class TextMessageProcessors : ITextMessageProcessors
    {
        readonly IInstancesOf<ICanProcessTextMessage> _processors;
        readonly ICommandContextManager _commandContextManager;
        readonly ILogger _logger;

        public TextMessageProcessors(
            IInstancesOf<ICanProcessTextMessage> processors,
            ICommandContextManager commandContextManager,
            ILogger logger)
        {
            _processors = processors;
            _commandContextManager = commandContextManager;
            _logger = logger;
        }

        public bool HasProcessors => _processors?.Any()?? false;

        public void Process(TextMessage message)
        {
            var commandContext = _commandContextManager.EstablishForCommand(
                new CommandRequest(
                    TransactionCorrelationId.New(),
                    null,
                    new Dictionary<string, object>())
            );

            _processors.ForEach(processor =>
            {
                try
                { 
                    processor.Process(message);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Problems processing message");
                }
            });

            commandContext.Commit();
        }
    }
}