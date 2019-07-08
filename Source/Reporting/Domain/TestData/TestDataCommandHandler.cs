using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Concepts.DataCollectors;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Serialization.Json;
using Domain.Management.DataCollectors;
using Domain.Management.DataCollectors.Registration;
using Domain.Reporting.CaseReports;
using Domain.TestData.CaseReports;
using Domain.TestData.Data;
using Domain.TestData.HealthRisks;

namespace Domain.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<HealtRisk> _healthRiskAggregate;
        readonly IAggregateRootRepositoryFor<DataCollector> _dataCollectorAggregate;
        readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingAggregate;

        readonly ISerializer _serializer;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<HealtRisk> healthRiskAggregate,
            IAggregateRootRepositoryFor<DataCollector> dataCollectorAggregate,
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregate, ISerializer serializer)
        {
            _healthRiskAggregate = healthRiskAggregate;
            _dataCollectorAggregate = dataCollectorAggregate;
            _caseReportingAggregate = caseReportingAggregate;
            _serializer = serializer;
        }

        T DeserializeTestData<T>(string path)
        {
            var assembly = typeof(TestDataCommandHandler).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + path))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var result = _serializer.FromJson<T>(json);
                    return result;
                }
            }
        }

        public void Handle(PopulateCaseReportTestData cmd)
        {
            var healthRisks = DeserializeTestData<HealthRiskTestDataHelper[]>("TestData.Data.HealthRisks.json");
            var dataCollectors = DeserializeTestData<RegisterDataCollector[]>("TestData.Data.DataCollectors.json");
            var caseReports = DeserializeTestData<CaseReportTestDataHelper[]>("TestData.Data.CaseReports.json");

            CreateHealthRisks(healthRisks);
            CreateDataCollectors(dataCollectors);
            CreateCaseReports(caseReports, dataCollectors, healthRisks);
        }

        private void CreateCaseReports(CaseReportTestDataHelper[] caseReports, RegisterDataCollector[] dataCollectors,
            HealthRiskTestDataHelper[] healthRisks)
        {
            var provider = CultureInfo.InvariantCulture;

            foreach (var caseReport in caseReports)
            {
                var root = _caseReportingAggregate.Get(Guid.NewGuid());
                var healthRisk = healthRisks.FirstOrDefault(h => h.Id == caseReport.HealthRiskId);
                var dataCollector = dataCollectors.FirstOrDefault(d => d.DataCollectorId == caseReport.DataCollectorId);

                root.Report(caseReport.DataCollectorId,
                    caseReport.HealthRiskId,
                    caseReport.Origin,
                    caseReport.NumberOfMalesUnder5,
                    caseReport.NumberOfMalesAged5AndOlder,
                    caseReport.NumberOfFemalesUnder5,
                    caseReport.NumberOfFemalesAged5AndOlder,
                    dataCollector.GpsLocation.Longitude,
                    dataCollector.GpsLocation.Latitude,
                    DateTimeOffset.ParseExact(caseReport.Timestamp, "dd/MM/yyyy HH:mm:ss zzz", provider, DateTimeStyles.AdjustToUniversal),
                    caseReport.Message);
            }
        }

        private void CreateDataCollectors(RegisterDataCollector[] dataCollectors)
        {
            foreach (var dataCollector in dataCollectors)
            {
                var root = _dataCollectorAggregate.Get(dataCollector.DataCollectorId.Value);

                if (dataCollector.GpsLocation == null)
                    dataCollector.GpsLocation = new Location(0, 0);

                if (dataCollector.PhoneNumbers == null)
                    dataCollector.PhoneNumbers = new List<PhoneNumber>();

                root.RegisterDataCollector(dataCollector.FullName, dataCollector.DisplayName, dataCollector.YearOfBirth,
                    dataCollector.Sex, dataCollector.PreferredLanguage, dataCollector.GpsLocation
                    , dataCollector.PhoneNumbers, DateTimeOffset.UtcNow, dataCollector.Region, dataCollector.District, Guid.NewGuid());
            }
        }

        private void CreateHealthRisks(HealthRiskTestDataHelper[] healthRisks)
        {
            foreach (var healthRisk in healthRisks)
            {
                var root = _healthRiskAggregate.Get(healthRisk.Id.Value);

                root.HealthRisk(
                    healthRisk.Id,
                    healthRisk.Name,
                    "case definition",
                    healthRisk.ReadableId
                );
            }
        }
    }
}
