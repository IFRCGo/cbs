/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class AllReplyMessages : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReadModelRepositoryFor<ReplyMessagesConfig> _collection;

        public AllReplyMessages(IReadModelRepositoryFor<ReplyMessagesConfig> collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query;
    }
}