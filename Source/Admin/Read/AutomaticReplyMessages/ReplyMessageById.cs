/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessageById : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReadModelRepositoryFor<ReplyMessagesConfig> _collection;

        public Guid ReplyMessageId { get; set; }
        public ReplyMessageById(IReadModelRepositoryFor<ReplyMessagesConfig> collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query.Where(m => m.Id == ReplyMessageId);
    }    
}