/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Concepts.Projects;
using Concepts.AutomaticReplies;

namespace Read.Reporting.AutomaticReplyMessages
{
    public class AutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReply(Guid id)
        {
            Id = id;
        }
    }
}