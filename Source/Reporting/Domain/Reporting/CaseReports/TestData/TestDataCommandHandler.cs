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
using Dolittle.Serialization.Json;
using Newtonsoft.Json;

namespace Domain.Reporting.CaseReports.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingAggregate;
        readonly ISerializer _serializer;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregate, ISerializer serializer)
        {
            _caseReportingAggregate = caseReportingAggregate;
            _serializer = serializer;
        }

        T DeserializeTestData<T>(string path)
        {
            var assembly = typeof(TestDataCommandHandler).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name+"."+path))
            {
                using( var reader = new StreamReader(stream) )
                {
                    var json = reader.ReadToEnd();
                    var result = _serializer.FromJson<T>(json);
                    return result;
                }
            }               
        }

        public void Handle(PopulateCaseReportTestData cmd)
        {
            var dataCaseReportHelpers = DeserializeTestData<CaseReportHelper[]>("Reporting.CaseReports.TestData.Data.CaseReports.json");

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
                    dataCaseReportHelper.Message, 
                    dataCaseReportHelper.Region);
            }
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
            public string Region {get; set;}
        }
    }
}