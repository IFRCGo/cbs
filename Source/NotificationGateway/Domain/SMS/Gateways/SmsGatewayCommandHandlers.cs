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
            var apiKey = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var key = Encoding.UTF8.GetBytes(System.Guid.NewGuid().ToString("N"));
                var result = hash.ComputeHash(key);

                foreach (var b in result)
                    apiKey.Append(b.ToString("x2"));
            }

            var root = _repository.Get(command.SmsGatewayId.Value);
            root.RegisterSmsGateway(command.Name, apiKey.ToString());
        }

        public void Handle(AssignPhoneNumberToSmsGateway command)
        {
            var root = _repository.Get(command.SmsGatewayId.Value);
            root.AssignPhoneNumberToSmsGateway(command.PhoneNumber);
            root.EnableSmsGateway();
        }
        
    }
}
