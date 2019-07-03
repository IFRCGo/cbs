/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Concepts.DataCollectors;
using Concepts.HealthRisks;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Serialization.Json;
using Domain.Reporting.CaseReports.TestData.Data;
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
            var dataCaseReportHelpers = DeserializeTestData<CaseReportTestDataHelper[]>("Reporting.CaseReports.TestData.Data.CaseReports.json");
            var provider = CultureInfo.InvariantCulture;

            foreach (var dataCaseReportHelper in dataCaseReportHelpers)
            {
                var root = _caseReportingAggregate.Get(Guid.NewGuid());

                root.Report(dataCaseReportHelper.DataCollectorId,
                    dataCaseReportHelper.HealthRiskId,
                    dataCaseReportHelper.Origin,
                    dataCaseReportHelper.NumberOfMalesUnder5,
                    dataCaseReportHelper.NumberOfMalesAged5AndOlder,
                    dataCaseReportHelper.NumberOfFemalesUnder5,
                    dataCaseReportHelper.NumberOfFemalesAged5AndOlder,
                    0.0,
                    0.0,
                    DateTimeOffset.ParseExact(dataCaseReportHelper.Timestamp, "dd/MM/yyyy HH:mm:ss zzz", provider, DateTimeStyles.AdjustToUniversal),
                    dataCaseReportHelper.Message);
            }
        }
    }
}