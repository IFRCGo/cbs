/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Web
{
    public interface IReplyMessages
    {
        IEnumerable<ReplyMessage> GetAll();
        IEnumerable<ReplyMessage> GetById(Guid messageId);
        IEnumerable<ReplyMessage> GetById();
    }
}