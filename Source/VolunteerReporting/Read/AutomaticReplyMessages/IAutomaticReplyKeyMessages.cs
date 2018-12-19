/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.Project;
using Concepts.AutomaticReply;
using Concepts.HealthRisk;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<AutomaticReplyKeyMessage>
    {
        AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(ProjectId projectId, AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);
        IEnumerable<AutomaticReplyKeyMessage> GetAll();

        IEnumerable<AutomaticReplyKeyMessage> GetByProject(ProjectId projectId);

        void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, ProjectId projectId, HealthRiskId healthRiskId);
    }
}
