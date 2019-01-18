/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Domain;
using Dolittle.Commands.Handling;

namespace Domain.Management.DataCollectors
{
    public class DataCollectorCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<DataCollector> _repository;

        public DataCollectorCommandHandler(
            IAggregateRootRepositoryFor<DataCollector> repository
            )
        {
            _repository = repository;
        }
    }
}