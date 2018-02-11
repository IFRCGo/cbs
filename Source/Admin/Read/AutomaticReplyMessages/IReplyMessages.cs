/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Read.AutomaticReplyMessages
{
    public interface IReplyMessages
    {
        ReplyMessagesConfig Get();
        void Save(ReplyMessagesConfig config);
    }
}