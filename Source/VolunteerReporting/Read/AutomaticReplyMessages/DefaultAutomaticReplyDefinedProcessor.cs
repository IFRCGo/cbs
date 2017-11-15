using Concepts;
using doLittle.Events.Processing;
using Events.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyDefinedProcessor : ICanProcessEvents
    {
        readonly IDefaultAutomaticReplies _defaultAutomaticReplies;

        public DefaultAutomaticReplyDefinedProcessor(IDefaultAutomaticReplies defaultAutomaticReplies)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
        }

        public void Process(DefaultAutomaticReplyDefined @event)
        {
            var automaticReply = _defaultAutomaticReplies.GetByTypeAndLanguage((AutomaticReplyType)@event.Type, @event.Language) ?? new DefaultAutomaticReply(@event.Id);
            automaticReply.Id = @event.Id;
            automaticReply.Type = (AutomaticReplyType)@event.Type;
            automaticReply.Message = @event.Message;
            automaticReply.Language = @event.Language;
            _defaultAutomaticReplies.Save(automaticReply);
        }

    }
}
