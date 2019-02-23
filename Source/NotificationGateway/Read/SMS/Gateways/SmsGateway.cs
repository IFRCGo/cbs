using Concepts.SMS.Gateways;
using Dolittle.ReadModels;

namespace Read.SMS.Gateways
{
    public class SmsGateway : IReadModel
    {
        public SmsGateway(SmsGatewayId id)
        {
            Id = id;
        }
        public SmsGatewayId Id {get; set;}
        public string Name {get; set;}
        public bool Enabled {get; set;}
        public string PhoneNumber {get; set;}
        public string ApiKey {get; set;}
    }
}
