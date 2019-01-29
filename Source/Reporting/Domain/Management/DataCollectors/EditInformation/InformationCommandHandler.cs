using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class InformationCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<DataCollector> _repository; 

        public InformationCommandHandler(IAggregateRootRepositoryFor<DataCollector> repository) 
        {
            _repository = repository;
        }

        public void Handle(AddPhoneNumberToDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.AddPhoneNumber(command.PhoneNumber.Value);
        }

        public void Handle(ChangeBaseInformation command)
        {
            var root =_repository.Get(command.DataCollectorId.Value);
            root.ChangeBaseInformation(
                command.FullName,
                command.DisplayName,
                command.YearOfBirth,
                command.Sex,
                command.Region,
                command.District
            );
        }

        public void Handle(ChangePreferredLanguage command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.ChangePreferredLanguage(command.PreferredLanguage);
        }

        public void Handle(ChangeLocation command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.ChangeLocation(command.Location);
        }

        public void Handle(ChangeVillage command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.ChangeVillage(command.Village);
        }

        
        public void Handle(ChangeDataVerifier cmd)
        {
            var root = _repository.Get(cmd.DataCollectorId.Value);
            root.ChangeDataVerifier(cmd.DataVerifierId);
        }
        
        public void Handle(RemovePhoneNumberFromDataCollector cmd)
        {
            var root = _repository.Get(cmd.DataCollectorId.Value);
            root.RemovePhoneNumbers(cmd.PhoneNumber);
        }
        
    }
}
