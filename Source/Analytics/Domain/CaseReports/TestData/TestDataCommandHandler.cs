using System;
using System.IO;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Newtonsoft.Json;

namespace Domain.CaseReports.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<CaseReport> _caseReportAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<CaseReport> caseReportAggregate){
            _caseReportAggregate = caseReportAggregate;
        }

        public void Handle(PopulateCaseReportTestData cmd)

        {
            var dataCaseReportHelpers = JsonConvert.DeserializeObject<CaseReportHelper[]>(File.ReadAllText("../Domain/CaseReports/TestData/Data/CaseReports.json"));
            var root = _caseReportAggregate.Get(dataCaseReportHelpers[0].DataCollectorId);

            foreach (var dataCaseReportHelper in dataCaseReportHelpers)
            {
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
        public class CaseReportHelper
        {
            public Guid DataCollectorId { get; set; }
            public Guid HealthRiskId { get; set; }
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
