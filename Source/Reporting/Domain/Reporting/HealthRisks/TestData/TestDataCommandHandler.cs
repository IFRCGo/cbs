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

namespace Domain.Reporting.HealthRisks.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<HealthRisk> _healthRiskAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<HealthRisk> healthRiskAggregate)
        {
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

        public void Handle(PopulateHealthRiskTestData cmd)
        {
            var risks = DeserializeTestData<HealthRiskHelper[]>("Reporting.HealthRisks.TestData.Data.HealthRisks.json");

            foreach (var risk in risks)
            {
                var root = _healthRiskAggregate.Get(risk.Id.Value);
                root.CreateHealthRisk(risk.Name, risk.ReadableId);
            }
        }
        // TODO: move class to a seperate file.cs
        public class HealthRiskHelper
        {
            public HealthRiskId Id { get; set; }
            public HealthRiskReadableId ReadableId { get; set; }
            public HealthRiskName Name { get; set; }
        }
    }
}