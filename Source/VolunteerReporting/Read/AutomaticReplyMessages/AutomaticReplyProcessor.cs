/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Events.AutomaticReplyMessages;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IAutomaticReplies _automaticReplies;
        private readonly IAutomaticReplyKeyMessages _keyMessages;

        public AutomaticReplyProcessor(IAutomaticReplies automaticReplies, IAutomaticReplyKeyMessages keyMessages)
        {
            _automaticReplies = automaticReplies;
            _keyMessages = keyMessages;
        }
        [EventProcessor("86e465ce-9267-4930-9cd3-903c854081cb")]
        public void Process(AutomaticReplyDefined @event)
        {
            _automaticReplies.SaveAutomaticReply(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message,
                @event.ProjectId);
            
        }
        [EventProcessor("da96f8e2-7ddf-42c2-ba06-b81736d98ca7")]
        public void Process(AutomaticReplyRemoved @event)
        {
            _automaticReplies.Delete(e => e.Id == @event.Id);
        }
        [EventProcessor("5b939ea7-16f2-4423-aa03-66c30c888795")]
        public void Process(AutomaticReplyKeyMessageDefined @event)
        {
            _keyMessages.SaveAutomaticReplyKeyMessage(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message,
                @event.ProjectId,
                @event.HealthRiskId);
            
        }
        [EventProcessor("0a354e24-99ed-46df-93bd-38571c49fb5c")]
        public void Process(AutomaticReplyKeyMessageRemoved @event)
        {
            _keyMessages.Delete(e => e.Id == @event.Id);
        }
    }
}
