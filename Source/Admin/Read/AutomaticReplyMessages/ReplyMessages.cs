/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessages : IReplyMessages
    {
        private readonly IMongoCollection<ReplyMessagesConfig> _collection;

        public ReplyMessages(IMongoDatabase database)
        {
            _collection = database.GetCollection<ReplyMessagesConfig>("ReplyMessagesConfig");
        }
        public ReplyMessagesConfig Get()
        {
            var config = _collection.Find(_ => true).FirstOrDefault();
            return config ?? new ReplyMessagesConfig
            {
                Messages = new Dictionary<string, IDictionary<string, string>> {
                {
               "sample", new Dictionary<string, string>{{"en-GB", "Your message was received, thank you."}}
                }
           }
            };
        }

        public void Save(ReplyMessagesConfig config)
        {
            if (_collection.Find(_ => true).FirstOrDefault() == null)
                _collection.InsertOne(config);
            else
                _collection.ReplaceOne(Builders<ReplyMessagesConfig>.Filter.Empty, config);
        }
    }
}