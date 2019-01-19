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
using Events.Admin.Reporting.HealthRisks;
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
        public void Handle(PopulateHealthRiskTestData cmd)
        {
            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(System.IO.File.ReadAllText("../Domain/Reporting/HealthRisks/TestData/Data/HealthRisks.json"));
            foreach (var risk in risks)
            {
                var root = _healthRiskAggregate.Get(risk.Id);
                root.CreateHealthRisk(risk.Name, risk.ReadableId);
            }
        }
    }
}