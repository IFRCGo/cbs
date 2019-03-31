using System;
using System.Globalization;
using Core.Security;
using Dolittle.Commands;
using Dolittle.Commands.Coordination;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.Logging;
using Dolittle.Tenancy;
using Domain.SMS.Gateways;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.GatewayEndpoints
{
    [Route("/smseagle/")]
    public class SmsEagleController : ControllerBase, ICanBypassSecurity
    {
        readonly ITenantMapper _mapper;
        readonly IExecutionContextManager _contextManager;
        readonly ICommandCoordinator _commandCoordinator;

        public SmsEagleController(
            ITenantMapper mapper,
            IExecutionContextManager contextManager,
            ICommandCoordinator commandCoordinator)
        {
            _mapper = mapper;
            _contextManager = contextManager;
            _commandCoordinator = commandCoordinator;
        }

        public bool ShouldBypassSecurity(HttpContext httpContext)
        {
            return httpContext.Request.Path.Equals("/notifications/smseagle/incoming") || httpContext.Request.Path.Equals("/smseagle/incoming");
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

            
            var command = new ReceiveMessageFromSMSGateway {
                Id = Guid.NewGuid(),
                Sender = sms.Sender,
                Text = sms.Text,
                Received = DateTimeOffset.ParseExact(sms.Timestamp, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal),
                ApiKey = sms.ApiKey,
                GatewayId = sms.MsgID,
                OID = sms.OID,
                ModemNumber = sms.ModemNo,
            };

            var result = _commandCoordinator.Handle(command);
            
            if (!result.Success)
            {
                throw new ReceiveMessageFromSMSGatewayFailed(command, result);
            }

            return Ok();
        }

        public class SMS
        {
            public string ApiKey {  get; set; }
            public string Sender {  get; set; }
            public string Timestamp {  get; set; }
            public int MsgID {  get; set; }
            public string OID { get; set; }
            public int ModemNo {  get; set; }
            public string Text {  get; set; }
        }
    }
}