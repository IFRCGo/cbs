using System.Security.Cryptography;
using System.Text;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
namespace Domain.SMS.Gateways
{
    public class SmsGatewayCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<SmsGatewayAggregate>  _repository;

        public SmsGatewayCommandHandlers(
            IAggregateRootRepositoryFor<SmsGatewayAggregate>  aggregateRootRepoForSmsGatewayAggregate            
        )
        {
             _repository =  aggregateRootRepoForSmsGatewayAggregate;
        }

        public void Handle(RegisterSmsGateway command)
        {
            var root = _repository.Get(command.SmsGatewayId.Value);
            root.RegisterSmsGateway(command.Name, command.ApiKey);
        }

        public void Handle(AssignPhoneNumberToSmsGateway command)
        {
            var root = _repository.Get(command.SmsGatewayId.Value);
            root.AssignPhoneNumberToSmsGateway(command.PhoneNumber);
            root.EnableSmsGateway();
        }
        
    }
}
