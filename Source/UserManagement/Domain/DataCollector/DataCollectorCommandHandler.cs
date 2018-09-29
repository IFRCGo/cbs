/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Domain;
using Dolittle.Commands.Handling;
using Domain.DataCollector.Changing;
using Domain.DataCollector.Registering;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.TrainingStatus;

namespace Domain.DataCollector
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

        public void Handle(RegisterDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.RegisterDataCollector(
                command.FullName,
                command.DisplayName,
                command.YearOfBirth,
                command.Sex,
                command.PreferredLanguage,
                command.GpsLocation,
                command.PhoneNumbers,
                DateTimeOffset.UtcNow,
                command.Region,
                command.District
                );
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

        public void Handle(DeleteDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.DeleteDataCollector();
        }

        public void Handle(ChangeVillage command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.ChangeVillage(command.Village);
        }

        public void Handle(AddPhoneNumberToDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.AddPhoneNumber(command.PhoneNumber);
        }

        public void Handle(RemovePhoneNumberFromDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId.Value);
            root.RemovePhoneNumbers(command.PhoneNumber);
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
