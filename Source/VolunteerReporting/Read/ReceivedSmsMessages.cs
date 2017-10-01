using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
   
    public class ReceivedSmsMessages : IReceivedSmsMessages {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Message> _collection;

        public ReceivedSmsMessages(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<Message>("ReceivedSmsMessage");
        }

        public Message GetById(Guid id)
        {
            var message = _collection.Find(c => c.Id == id).SingleOrDefault();
            if (message == null)
            {
               throw new InvalidOperationException(); //should not happen
            }
            return message;
        }

        public IEnumerable<Message> ListByPhonenumber(PhoneNumber phoneNumber) {
            throw new NotImplementedException();
            //TODO: Find all messages from that number
        }

        public void Save(Message receivedSmsMessage)
        {
            var filter = Builders<Message>.Filter.Eq(c => c.Id, receivedSmsMessage.Id);
            _collection.ReplaceOne(filter, receivedSmsMessage);
        }

       
    }
}