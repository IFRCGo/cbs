/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Runtime.Commands;
using doLittle.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    public class CommandHandlers : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<DataCollector> _repository;

        public CommandHandlers(
            IAggregateRootRepositoryFor<DataCollector> repository
            )
        {
            _repository = repository;
        }

        //TODO: Should handle AddDataCollector aswell?? 

        public void Handle(AddPhoneNumber command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.AddPhoneNumber(command.PhoneNumber);
        }

        public void Handle(RemovePhoneNumber command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.RemovePhoneNumber(command.PhoneNumber);
        }
    }
}
