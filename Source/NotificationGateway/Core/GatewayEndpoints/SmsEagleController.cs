using Dolittle.Execution;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;

namespace Core.GatewayEndpoints
{
    [Route("/smseagle/")]
    public class SmsEagleController : ControllerBase
    {
        readonly ITenantMapper _mapper;
        readonly IExecutionContextManager _contextManager;

        public SmsEagleController(ITenantMapper mapper, IExecutionContextManager contextManager)
        {
            _mapper = mapper;
            _contextManager = contextManager;
        }

        [HttpPost("incoming")]
        public IActionResult IncomingSMS([FromForm] SMS sms)
        {
            var tenantId = _mapper.GetTenantFor(sms.ApiKey);
            
            if (tenantId == TenantId.Unknown)
            {
                return StatusCode(403);
            }

            _contextManager.CurrentFor(tenantId);

            return Ok();
        }


        public class SMS
        {
            public string ApiKey {  get; set; }
            public string Sender {  get; set; }
            public string Timestamp {  get; set; }
            public string MsgID {  get; set; }
            public string OID { get; set; }
            public string ModemNo {  get; set; }
            public string Text {  get; set; }
        }
    }
}