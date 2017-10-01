using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class ReceivedSmsMessage {
        public Guid Id { get; set; }
        public DateTime Sent { get; set; }
        /// <summary>
        /// Phone number of sender
        /// </summary>
        public String Sender { get; set; }  //Long? PhoneNumber custom type?
        public string Message { get; set; }
        //TODO: verify content with Kristian
    }
}
