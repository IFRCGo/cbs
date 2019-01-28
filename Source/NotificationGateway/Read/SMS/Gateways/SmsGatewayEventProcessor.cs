using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.SMS.Gateways;

namespace Read.SMS.Gateways
{
    public class SmsGatewayEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<SmsGateway> _repository;

        public SmsGatewayEventProcessor(
            IReadModelRepositoryFor<SmsGateway> repositoryForSmsGateway            
        )
        {
            _repository = repositoryForSmsGateway;
        }
        
        [EventProcessor("168a69bf-8269-afea-4391-48cedee978fd")]
        public void Process(SmsGatewayRegistered @event)
        { 
            _repository.Insert(new SmsGateway(@event.Id) {
                Name = @event.Name,
                ApiKey = @event.ApiKey
            });
        }
        
        [EventProcessor("10c0028d-5b45-4ffc-89e7-4bb3ce6e048a")]
        public void Process(SmsGatewayNumberAssigned @event)
        {
            var smsGateway = _repository.GetById(@event.Id);
            smsGateway.PhoneNumber = @event.PhoneNumber;

            _repository.Update(smsGateway);
        }

        [EventProcessor("c05abe8f-352f-4085-8d8e-5574746ed59b")]
        public void Process(SmsGatewayEnabled @event)
        {
            var smsGateway = _repository.GetById(@event.Id);
            smsGateway.Enabled = @event.Enabled;

            _repository.Update(smsGateway);
        }
    }
}
