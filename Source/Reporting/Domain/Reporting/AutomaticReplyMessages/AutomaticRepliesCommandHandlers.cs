/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Handling;
using Dolittle.Domain;
using System;

namespace Domain.Reporting.AutomaticReplyMessages
{
    public class AutomaticRepliesCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<AutomaticReplyDefinition> _automaticReplyRepository;

        public AutomaticRepliesCommandHandlers(IAggregateRootRepositoryFor<AutomaticReplyDefinition> automaticReplyRepository)
        {
            _automaticReplyRepository = automaticReplyRepository;
        }

        public void Handle(DefineAutomaticReplyForProject automaticReply)
        {
            var eventId = Guid.NewGuid();
            var repository = _automaticReplyRepository.Get(eventId);
            repository.Define(
                automaticReply.ProjectId,
                automaticReply.Type,
                automaticReply.Language,
                automaticReply.Message
                );
        }

        public void Handle(DefineAutomaticReplyKeyMessageForProject automaticReplyKeyMessage)
        {
            var eventId = Guid.NewGuid();
            var repository = _automaticReplyRepository.Get(eventId);
            repository.DefineKeyMessage(
                automaticReplyKeyMessage.ProjectId,
                automaticReplyKeyMessage.HealthRiskId,
                automaticReplyKeyMessage.Type,
                automaticReplyKeyMessage.Language,
                automaticReplyKeyMessage.Message
                );
        }
    }
}