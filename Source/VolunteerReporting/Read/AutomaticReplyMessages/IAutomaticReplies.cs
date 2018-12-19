/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.Project;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies : IExtendedReadModelRepositoryFor<AutomaticReply>
    {
        AutomaticReply GetByProjectTypeAndLanguage(ProjectId projectId, AutomaticReplyType type, string language);

        IEnumerable<AutomaticReply> GetAll();

        IEnumerable<AutomaticReply> GetByProject(ProjectId projectId);

        void SaveAutomaticReply(Guid id, int type, string language, string message, Guid projectId);
    }
}
