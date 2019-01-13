/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.Project;
using Concepts.AutomaticReply;
using Dolittle.Commands;

namespace Domain.AutomaticReplyMessages
{
    public class DefineAutomaticReplyForProject : ICommand
    {
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
