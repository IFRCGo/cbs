/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.AutomaticReplyMessages;
using System.Linq;

namespace Rules.AutomaticReplyMessages
{
    public class IsTagValidRule : IRuleImplementationFor<IsTagValid>
    {
        public IsTagValid Rule => (string tag) =>
        {
            return !string.IsNullOrWhiteSpace(tag) && tag.All(char.IsLetterOrDigit);
        };
    }
}
