using System;
using System.IO;
using Dolittle.Runtime.Commands;
using Domain.SMS.Gateways;
using System.Linq;

namespace Core.GatewayEndpoints
{
    public class ReceiveMessageFromSMSGatewayFailed : Exception
    {
        public ReceiveMessageFromSMSGatewayFailed(ReceiveMessageFromSMSGateway command, CommandResult result)
            : base($"Receiving message '{command.Text}' from '{command.Sender}' failed. Validation [{String.Join(',', result.ValidationResults.Select(_ => _.ErrorMessage))}], Security [{String.Join(',', result.SecurityMessages)}]", result.Exception)
        {
        }
    }
}