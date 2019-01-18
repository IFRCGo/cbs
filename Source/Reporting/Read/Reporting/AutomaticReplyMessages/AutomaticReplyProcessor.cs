/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.AutomaticReplies;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.AutomaticReplyMessages;

namespace Read.Reporting.AutomaticReplyMessages
{
    public class AutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<AutomaticReply> _automaticReplies;
        private readonly IReadModelRepositoryFor<AutomaticReplyKeyMessage> _keyMessages;

        public AutomaticReplyProcessor(IReadModelRepositoryFor<AutomaticReply> automaticReplies, IReadModelRepositoryFor<AutomaticReplyKeyMessage> keyMessages)
        {
            _automaticReplies = automaticReplies;
            _keyMessages = keyMessages;
        }
        [EventProcessor("86e465ce-9267-4930-9cd3-903c854081cb")]
        public void Process(AutomaticReplyDefined @event)
        {
            var reply = _automaticReplies.GetById(@event.Id);
            reply.Language = @event.Language;
            reply.Message = @event.Message;
            reply.ProjectId = @event.ProjectId;
            reply.Type = (AutomaticReplyType) @event.Type;

            _automaticReplies.Update(reply);
        }
        [EventProcessor("da96f8e2-7ddf-42c2-ba06-b81736d98ca7")]
        public void Process(AutomaticReplyRemoved @event)
        {
            var reply = _automaticReplies.GetById(@event.Id);
            _automaticReplies.Delete(reply);
        }
        [EventProcessor("5b939ea7-16f2-4423-aa03-66c30c888795")]
        public void Process(AutomaticReplyKeyMessageDefined @event)
        {
            var keyMessage = _keyMessages.GetById(@event.Id);
            keyMessage.Id = @event.Id;
            keyMessage.Type = (AutomaticReplyKeyMessageType) @event.Type;
            keyMessage.Language = @event.Language;
            keyMessage.Message = @event.Message;
            keyMessage.ProjectId = @event.ProjectId;
            keyMessage.HealthRiskId = @event.HealthRiskId;

            _keyMessages.Update(keyMessage);
        }
        [EventProcessor("0a354e24-99ed-46df-93bd-38571c49fb5c")]
        public void Process(AutomaticReplyKeyMessageRemoved @event)
        {
            var keyMessage = _keyMessages.GetById(@event.Id);
            _keyMessages.Delete(keyMessage);
        }
    }
}