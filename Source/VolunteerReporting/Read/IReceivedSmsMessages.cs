using System;
using System.Collections.Generic;

namespace Read
{
    public interface IReceivedSmsMessages
    {
        Message GetById(Guid id);
        IEnumerable<Message> ListByPhonenumber(PhoneNumber phoneNumber);
        void Save(Message receivedSmsMessage);
    }
}