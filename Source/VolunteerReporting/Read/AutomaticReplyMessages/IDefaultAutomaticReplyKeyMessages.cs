/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.AutomaticReply;
using Concepts.HealthRisk;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage>
    {
        DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);

        IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll();

        void SaveDefaultAutomaticReplyKeyMessage(Guid id, int type, string language, string message, HealthRiskId healthRiskId);
    }
}
