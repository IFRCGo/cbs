/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.AutomaticReply;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.AutomaticReplyMessages;

namespace Domain.AutomaticReplyMessages
{
    public class AutomaticReplyDefinition : AggregateRoot
    {
        public AutomaticReplyDefinition(EventSourceId eventSourceId): base(eventSourceId)
        {

        }

        public void Define(Guid projectId, AutomaticReplyType type, string language, string message)
        {
            Apply(new AutomaticReplyDefined(Guid.NewGuid(), projectId, (int)type, language, message));
        }

        public void DefineKeyMessage(Guid projectId, Guid healthRiskId, AutomaticReplyKeyMessageType type, string language, string message)
        {
            Apply(new AutomaticReplyKeyMessageDefined(Guid.NewGuid(), projectId, healthRiskId, (int)type, language, message));
        }
    }
}