/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Runtime.Commands;
using doLittle.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataCollectors.AggregateRoots;
using Domain.DataCollectors.Commands;

namespace Domain.DataCollectors.CommandHandlers
{
    public class DataCollectorCommandHandler : ICanHandleCommands
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

    }
}
