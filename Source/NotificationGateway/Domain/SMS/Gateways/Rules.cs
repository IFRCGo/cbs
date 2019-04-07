using System;
using Concepts.SMS;
using Concepts.SMS.Gateways;

namespace Domain.SMS.Gateways
{
    public delegate bool PhoneNumberNotExists(string number);
    public delegate bool SmsGatewayDoesNotExist(Guid id);
    public delegate bool SMSGatewayMustBeEnabled(ApiKey apiKey);
}