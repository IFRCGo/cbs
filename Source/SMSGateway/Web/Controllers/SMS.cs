using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class SMS
    {
        public string Sender { get; set; }
        public long Timestamp { get; set; }
        public int MsgID { get; set; }
        public int ModemNo { get; set; }
        public string Text { get; set; }
    }
}
