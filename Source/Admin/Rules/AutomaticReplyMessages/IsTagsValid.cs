/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.AutomaticReplyMessages;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Rules;

namespace Rules.AutomaticReplyMessages
{
    public class IsTagsValid : IRuleImplementationFor<Domain.AutomaticReplyMessages.IsTagsValid>
    {
        private readonly Domain.AutomaticReplyMessages.IsTagValid _isTagValid; 
        public IsTagsValid(Domain.AutomaticReplyMessages.IsTagValid isTagValid)
        {
            _isTagValid = isTagValid; 
        }

        public Domain.AutomaticReplyMessages.IsTagsValid Rule => (IEnumerable<string> tags) =>
        {
            return tags.All(_ =>_isTagValid(_));
        };
    }
}
