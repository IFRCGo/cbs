using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Events;

namespace Events
{
    public class SmsSentEvent : IEvent
    {
        public string RecipientName { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
