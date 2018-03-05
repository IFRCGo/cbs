/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using doLittle.Domain;
using Domain.DataCollector.Registering;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;

namespace Domain.DataCollector
{
    public class DataCollectorCommandHandler
    {
        private readonly IAggregateRootRepositoryFor<DataCollector> _repository;

        public DataCollectorCommandHandler (
            IAggregateRootRepositoryFor<DataCollector> repository
            )
        {
            _repository = repository;
        }

        public void Handle(RegisterDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.RegisterDataCollector(
                command.FullName,
                command.DisplayName,
                command.YearOfBirth,
                command.Sex,
                command.NationalSociety,
                command.PreferredLanguage,
                command.GpsLocation,
                command.PhoneNumbers,
                DateTimeOffset.UtcNow
                );
        }

        public void Handle(UpdateDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.UpdateDataCollector(
                command.FullName,
                command.DisplayName,
                command.NationalSociety,
                command.PreferredLanguage,
                command.GpsLocation,
                command.PhoneNumbersAdded,
                command.PhoneNumbersRemoved
                );

        }
        public void Handle(AddPhoneNumberToDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.AddPhoneNumber(command.PhoneNumber);
        }

        public void Handle(RemovePhoneNumberFromDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.RemovePhoneNumber(command.PhoneNumber);
        }
    }
}
