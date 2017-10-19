using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Events;

namespace Events
{
    public class EmailSentEvent : IEvent
    {
        public string RecipientName { get; set; }
        public string RecipientEmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
