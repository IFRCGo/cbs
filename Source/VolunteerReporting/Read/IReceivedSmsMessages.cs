using System;
using System.Collections.Generic;

namespace Read
{
    public interface IReceivedSmsMessages
    {
        ReceivedSmsMessage GetById(Guid id);
        IEnumerable<ReceivedSmsMessage> ListByPhonenumber(PhoneNumber phoneNumber);
        void Save(ReceivedSmsMessage receivedSmsMessage);
    }
}