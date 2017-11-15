using Concepts;
using doLittle.Events.Processing;
using Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyDefinedProcessor : ICanProcessEvents
    {
        readonly IAutomaticReplies _automaticReplies;

        public AutomaticReplyDefinedProcessor(IAutomaticReplies automaticReplies)
        {
            _automaticReplies = automaticReplies;
        }

        public async Task Process(AutomaticReplyDefined @event)
        {
            var automaticReply = await _automaticReplies.GetByProjectTypeAndLanguageAsync(@event.ProjectId, (AutomaticReplyType)@event.Type, @event.Language) ?? new AutomaticReply(@event.Id);
            automaticReply.Id = @event.Id;
            automaticReply.ProjectId = @event.ProjectId;
            automaticReply.Type = (AutomaticReplyType)@event.Type;
            automaticReply.Message = @event.Message;
            automaticReply.Language = @event.Language;
            _automaticReplies.Save(automaticReply);
        }
    }
}
