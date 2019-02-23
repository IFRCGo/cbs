using System;
using Concepts.SMS;

namespace Domain.SMS.Gateways
{
    public delegate bool PhoneNumberNotExists(string number);
    public delegate bool SmsGatewayDoesNotExist(Guid id);
}