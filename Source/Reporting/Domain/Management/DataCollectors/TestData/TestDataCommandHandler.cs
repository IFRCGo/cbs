/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Concepts.DataCollectors;
using Concepts.HealthRisks;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Newtonsoft.Json;

namespace Domain.Management.DataCollectors.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<DataCollector> _dataCollectorAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<DataCollector> dataCollectorAggregate)
        {
            _dataCollectorAggregate = dataCollectorAggregate;
        }

        public void Handle(PopulateDataCollectorTestData cmd)
        {
            var dataCollectors = JsonConvert.DeserializeObject<Registration.RegisterDataCollector[]>(File.ReadAllText("../Domain/Management/DataCollectors/TestData/Data/DataCollectors.json"));

            foreach (var dataCollector in dataCollectors)
            {
                var root = _dataCollectorAggregate.Get(dataCollector.DataCollectorId.Value);

                if(dataCollector.GpsLocation ==null)
                    dataCollector.GpsLocation = new Location(0,0);

                if (dataCollector.PhoneNumbers == null)
                    dataCollector.PhoneNumbers = new List<string>();

                root.RegisterDataCollector(dataCollector.FullName, dataCollector.DisplayName, dataCollector.YearOfBirth,
                    dataCollector.Sex, dataCollector.PreferredLanguage, dataCollector.GpsLocation
                    , dataCollector.PhoneNumbers, DateTimeOffset.UtcNow, dataCollector.Region, dataCollector.District, Guid.NewGuid());
            }
        }

    }
}