/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.HealthRisks;
using System;
using Dolittle.ReadModels;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskExistingRule : IRuleImplementationFor<IsHealthRiskExisting>
    {
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskExistingRule(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public IsHealthRiskExisting Rule => healthRiskId => _healthRisks.GetById(healthRiskId) != null;
    }
}
