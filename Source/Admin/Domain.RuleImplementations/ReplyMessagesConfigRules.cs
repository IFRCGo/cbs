/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ReplyMessage;

namespace Domain.RuleImplementations
{
    public class ReplyMessagesConfigRules : IReplyMessagesConfigRules
    {

        public bool IsTagsValid(IEnumerable<string> tags)
        {
            return tags.All(IsTagValid);
        }

        private bool IsTagValid(string tag)
        {
            return !string.IsNullOrWhiteSpace(tag) && tag.All(char.IsLetterOrDigit);
        }
    }
}