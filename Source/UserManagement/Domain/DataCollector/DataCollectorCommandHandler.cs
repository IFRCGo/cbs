/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Domain;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;

namespace Domain.DataCollector
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
            var root = _repository.Get(command.DataCollectorId);
            root.AddDataCollector(
                command.DataCollectorId,
                command.FullName,
                command.DisplayName,
                command.YearOfBirth,
                command.Sex,
                command.NationalSociety,
                command.PreferredLanguage,
                command.GpsLocation,
                command.Email,
                command.PhoneNumbers
                );
        }

        public void Handle(UpdateDataCollector command)
        {
            var root = _repository.Get(command.DataCollectorId);
            root.UpdateDataCollector(
                command.DataCollectorId,
                command.FullName,
                command.DisplayName,
                command.NationalSociety,
                command.PreferredLanguage,
                command.GpsLocation,
                command.Email,
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
