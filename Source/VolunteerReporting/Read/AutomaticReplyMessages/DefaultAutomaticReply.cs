/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.AutomaticReply;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReply(Guid id)
        {
            Id = id;
        }
    }
}