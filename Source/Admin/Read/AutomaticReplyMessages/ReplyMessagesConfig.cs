/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessagesConfig
    {
        public Guid Id { get; set; }
        public IDictionary<string, IDictionary<string,string>> Messages { get; set; }
    }
}