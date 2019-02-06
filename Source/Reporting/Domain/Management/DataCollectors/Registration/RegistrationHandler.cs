/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Management.DataCollectors.Registration
{

    public class RegistrationHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<DataCollector> _repository;

        public RegistrationHandler(IAggregateRootRepositoryFor<DataCollector> repository) 
        {
            _repository = repository;
        }
        
        public void Handle(RegisterDataCollector cmd)
        {
            var root = _repository.Get(cmd.DataCollectorId.Value);
            root.RegisterDataCollector(
                cmd.FullName,
                cmd.DisplayName,
                cmd.YearOfBirth,
                cmd.Sex,
                cmd.PreferredLanguage,
                cmd.GpsLocation,
                cmd.PhoneNumbers,
                DateTimeOffset.UtcNow,
                cmd.Region,
                cmd.District,
                cmd.DataVerifierId
                );
        }
        
        public void Handle(DeleteDataCollector cmd)
        {
            var root = _repository.Get(cmd.DataCollectorId.Value);
            root.DeleteDataCollector();
        }        
    }
}