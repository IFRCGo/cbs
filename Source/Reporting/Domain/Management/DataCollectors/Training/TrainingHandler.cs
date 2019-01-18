using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Management.DataCollectors.Training
{
    public class TrainingHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<DataCollector> _repository;

        public TrainingHandler(
            IAggregateRootRepositoryFor<DataCollector> repository
        )
        {
            _repository = repository;
        }
        public void Handle(BeginTraining command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.BeginTraining();
        }

        public void Handle(EndTraining command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.EndTraining();
        }
    }
}
