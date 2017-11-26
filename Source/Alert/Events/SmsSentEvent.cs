using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events
{
    public class SmsSentEvent : IEvent
    {
        public string RecipientName { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
