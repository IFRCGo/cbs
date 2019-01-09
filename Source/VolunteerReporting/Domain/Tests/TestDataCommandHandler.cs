/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Concepts.DataCollector;
using Concepts.HealthRisk;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Domain.CaseReports;
using Domain.DataCollectors;
using Domain.DataCollectors.Registration;
using Domain.HealthRisks;
using Newtonsoft.Json;

namespace Domain.Tests
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingAggregate;
        private readonly IAggregateRootRepositoryFor<DataCollector> _dataCollectorAggregate;
        private readonly IAggregateRootRepositoryFor<HealthRisk> _healthRiskAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregate, IAggregateRootRepositoryFor<DataCollector> dataCollectorAggregate, IAggregateRootRepositoryFor<HealthRisk> healthRiskAggregate)
        {
            _caseReportingAggregate = caseReportingAggregate;
            _dataCollectorAggregate = dataCollectorAggregate;
            _healthRiskAggregate = healthRiskAggregate;
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

                if(dataCollector.GpsLocation ==null)
                    dataCollector.GpsLocation = new Location(0,0);

                if (dataCollector.PhoneNumbers == null)
                    dataCollector.PhoneNumbers = new List<string>();

                root.RegisterDataCollector(dataCollector.FullName, dataCollector.DisplayName, dataCollector.YearOfBirth,
                    dataCollector.Sex, dataCollector.PreferredLanguage, dataCollector.GpsLocation
                    , dataCollector.PhoneNumbers, DateTimeOffset.UtcNow, dataCollector.Region, dataCollector.District);
            }
        }

        public void Handle(CreateHealthRiskTestData cmd)
        {
            var risks = DeserializeTestData<HealthRiskHelper[]>("Tests.Data.HealthRisks.json");

            foreach (var risk in risks)
            {
                var root = _healthRiskAggregate.Get(risk.Id.Value);
                root.CreateHealthRisk(risk.Name, risk.ReadableId);
            }
        }
 
        public void Handle(CreateCaseReportTestData cmd)
        {
            var dataCaseReportHelpers = DeserializeTestData<CaseReportHelper[]>("Tests.Data.CaseReports.json");

            foreach (var dataCaseReportHelper in dataCaseReportHelpers)
            {
                var root = _caseReportingAggregate.Get(dataCaseReportHelper.DataCollectorId.Value);

                root.Report(dataCaseReportHelper.DataCollectorId,
                    dataCaseReportHelper.HealthRiskId,
                    dataCaseReportHelper.Origin,
                    dataCaseReportHelper.NumberOfMalesUnder5,
                    dataCaseReportHelper.NumberOfMalesAged5AndOlder,
                    dataCaseReportHelper.NumberOfFemalesUnder5,
                    dataCaseReportHelper.NumberOfFemalesAged5AndOlder,
                    dataCaseReportHelper.Longitude,
                    dataCaseReportHelper.Latitude,
                    DateTimeOffset.UtcNow,
                    dataCaseReportHelper.Message);
            }
        }

        // TODO: move class to a seperate file.cs
        public class HealthRiskHelper
        {
            public HealthRiskId Id { get; set; }
            public HealthRiskReadableId ReadableId { get; set; }
            public HealthRiskName Name { get; set; }
        }

        // TODO: move class to a seperate file.cs
        public class CaseReportHelper
        {
            public DataCollectorId DataCollectorId { get; set; }
            public HealthRiskId HealthRiskId { get; set; }
            public string Origin { get; set; }
            public int NumberOfMalesUnder5 { get; set; }
            public int NumberOfMalesAged5AndOlder { get; set; }
            public int NumberOfFemalesUnder5 { get; set; }
            public int NumberOfFemalesAged5AndOlder { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public string Message { get; set; }
        }
    }
}