/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.AutomaticReplyMessages;
using Infrastructure.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.RuleImplementations.AutomaticReplyMessages
{
    public class IsTagsValidRule : IRuleImplementationFor<IsTagsValid>
    {
        private readonly IsTagValid _isTagValid; 
        public IsTagsValidRule(IsTagValid isTagValid)
        {
            _isTagValid = isTagValid; 
        }

        public IsTagsValid Rule => (IEnumerable<string> tags) =>
        {
            return tags.All(_ =>_isTagValid(_));
        };

    }
}
