using Microsoft.AspNetCore.Mvc;

namespace Core.GatewayEndpoints
{
    [Route("/smseagle/")]
    public class SmsEagleController : ControllerBase
    {
        [HttpPost("incoming")]
        public IActionResult IncomingSMS([FromForm] SMS sms)
        {
            return Ok();
        }


        public class SMS
        {
            public string Sender {  get; set; }
            public string Timestamp {  get; set; }
            public string MsgID {  get; set; }
            public string OID { get; set; }
            public string ModemNo {  get; set; }
            public string Text {  get; set; }
        }
    }
}