/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read.TextMessageRecievedFeatures
{
   
    public class ReceivedTextMessages : IReceivedTextMessages {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<RecievedTextMessage> _collection;

        public ReceivedTextMessages(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<RecievedTextMessage>("ReceivedTextMessage");
        }

        public RecievedTextMessage GetById(Guid id)
        {
            var message = _collection.Find(c => c.Id == id).SingleOrDefault();            
            return message;
        }

        public IEnumerable<RecievedTextMessage> ListByPhonenumber(PhoneNumber phoneNumber) {
            throw new NotImplementedException();
            //TODO: Find all messages from that number
        }

        public void Save(RecievedTextMessage receivedTextMessage)
        {
            var filter = Builders<RecievedTextMessage>.Filter.Eq(c => c.Id, receivedTextMessage.Id);
            _collection.ReplaceOne(filter, receivedTextMessage);
        }

       
    }
}