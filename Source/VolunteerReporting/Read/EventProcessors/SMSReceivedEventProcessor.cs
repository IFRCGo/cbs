using Events.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class SMSReceivedEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IReceivedSmsMessages _receivedSmsMessages;

        public SMSReceivedEventProcessor(IReceivedSmsMessages receivedSmsMessages)
        {
            _receivedSmsMessages = receivedSmsMessages;
        }

        public void Process(SMSReceived @event)
        {

        }
    }
}
