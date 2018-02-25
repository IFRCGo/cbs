/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Domain;
using System;
using Domain.DataCollectors.AggregateRoots;
using Domain.DataCollectors.Commands;

namespace Domain.DataCollectors.CommandHandlers
{
    public class DataCollectorCommandHandler : IDataCollectorCommandHandler
    {
        private readonly IAggregateRootRepositoryFor<DataCollectorManagement> _repository;

        public DataCollectorCommandHandler (
            IAggregateRootRepositoryFor<DataCollectorManagement> repository
            )
        {
            _repository = repository;
        }

        public void Handle(AddDataCollector command)
        {
            var root = _repository.Get(Guid.NewGuid());
            root.AddDataCollector(command);
        }

        public void Handle(UpdateDataCollector command)
        {
            var root = _repository.Get(Guid.NewGuid());
            root.UpdateDataCollector(command);

        }
        public void Handle(AddPhoneNumberToDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId); //TODO: Or Guid.NewGuid()
            root.AddPhoneNumber(command);
        }

        public void Handle(RemovePhoneNumberFromDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId); //TODO: Or Guid.NewGuid()
            root.RemovePhoneNumber(command);
        }
    }
}
