/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplies : IExtendedReadModelRepositoryFor<DefaultAutomaticReply>
    {
        DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyType type, string language);
        IEnumerable<DefaultAutomaticReply> GetAll();
        void SaveDefaultAutomaticReply(Guid id, int type, string language, string message);
    }
}