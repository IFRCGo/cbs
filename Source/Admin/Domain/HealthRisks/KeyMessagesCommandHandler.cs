using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.HealthRisks
{
    public class KeyMessagesCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<HealthRisk> _repository;

        public KeyMessagesCommandHandler(IAggregateRootRepositoryFor<HealthRisk> repository)
        {
            _repository = repository;
        }

        public void Handle(AddKeyMessageToHealthRisk command)
        {
            var healthRisk = _repository.Get(command.HealthRisk);
            healthRisk.AddKeyMessage(command.KeyMessage);

        }        
    }
}