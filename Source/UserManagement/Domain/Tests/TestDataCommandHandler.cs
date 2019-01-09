/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Domain.DataCollectors;
using Newtonsoft.Json;

namespace Domain.Tests
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<DataCollector> _dataCollectorAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<DataCollector> dataCollectorAggregate)
        {
            _dataCollectorAggregate = dataCollectorAggregate;
        }

        T DeserializeTestData<T>(string path)
        {
            var assembly = typeof(TestDataCommandHandler).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name+"."+path))
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var result = new JsonSerializer().Deserialize<T>(reader);
                return result;
            }
        }

        public void Handle(CreateDataCollectorTestData cmd)
        {
            var dataCollectors = DeserializeTestData<RegisterDataCollector[]>("Tests.Data.DataCollectors.json");

            foreach (var dataCollector in dataCollectors)
            {
                var root = _dataCollectorAggregate.Get(dataCollector.DataCollectorId.Value);

                root.RegisterDataCollector(dataCollector.FullName, dataCollector.DisplayName, dataCollector.YearOfBirth,
                    dataCollector.Sex, dataCollector.PreferredLanguage, dataCollector.GpsLocation,
                    dataCollector.PhoneNumbers, DateTimeOffset.UtcNow, dataCollector.Region, dataCollector.District,
                    dataCollector.DataVerifierId);
            }
        }

        //public void Handle(CreateAdminTestData cmd)
        //{
        //    var admins = JsonConvert.DeserializeObject<RegisterAdmin[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/Admin.json"));

        //    foreach (var admin in admins)
        //    {

        //    }
        //}

        //public void Handle(CreateDataConsumerTestData cmd)
        //{
        //    var dataConsumers = JsonConvert.DeserializeObject<RegisterDataConsumer[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/DataConsumers.json"));

        //    foreach (var dc in dataConsumers)
        //    {

        //    }
        //}

        //public void Handle(CreateDataCoordinatorTestData cmd)
        //{
        //    var dataCoordinators = JsonConvert.DeserializeObject<RegisterCoordinator[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/DataCoordinators.json"));

        //    foreach (var dc in dataCoordinators)
        //    {

        //    }
        //}

        //public void Handle(CreateDataOwnerTestData cmd)
        //{
        //    var dataOwners = JsonConvert.DeserializeObject<RegisterDataOwner[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/DataOwners.json"));

        //    foreach (var dc in dataOwners)
        //    {

        //    }
        //}

        //public void Handle(CreateDataVerifiersTestData cmd)
        //{
        //    var dataVerifiers = JsonConvert.DeserializeObject<RegisterDataVerifier[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/DataVerifiers.json"));

        //    foreach (var dc in dataVerifiers)
        //    {

        //    }
        //}

        //public void Handle(CreateSystemConfiguratorTestData cmd)
        //{
        //    var systemConfigurators = JsonConvert.DeserializeObject<CreateSystemConfigurator[]>(
        //        System.IO.File.ReadAllText("../Domain/Tests/Data/DataOwnerss.json"));

        //    foreach (var dc in systemConfigurators)
        //    {

        //    }
        //}

    }
}