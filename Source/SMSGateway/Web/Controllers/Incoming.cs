using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("incoming")]
    public class IncomingController : Controller
    {
        [HttpPost]
        public void Receive([FromBody]SMS sms)
        {
            Console.WriteLine("---------------------------");
            
            Console.WriteLine("Sender: " + sms.Sender);
            Console.WriteLine("Timestamp: " + sms.Timestamp);
            Console.WriteLine("MSGID: " + sms.MsgID);
            Console.WriteLine("Modem: " + sms.ModemNo);
            Console.WriteLine("Text: " + sms.Text);

            Console.WriteLine("---------------------------");
        }
    }
}
