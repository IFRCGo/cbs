/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessagesConfig
    {
        public IDictionary<string, IDictionary<string,string>> Messages { get; set; }
    }
}