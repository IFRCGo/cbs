/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

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
