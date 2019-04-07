using Dolittle.Events.Processing;
using Dolittle.Execution;
using Events.SMS.Gateways;

namespace Core.GatewayEndpoints
{
    public class GatewayEventProcessor : ICanProcessEvents
    {
        readonly ITenantMapper _mapper;
        readonly IExecutionContextManager _contextManager;

        public GatewayEventProcessor(ITenantMapper mapper, IExecutionContextManager contextManager)
        {
            _mapper = mapper;
            _contextManager = contextManager;
        }

        [EventProcessor("e927bfb0-9b80-48e0-b3d7-109785a659bd")]
        public void Process(SmsGatewayRegistered @event)
        {
            _mapper.SetTenantFor(@event.ApiKey, _contextManager.Current.Tenant);
        }
    }
}