/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using HealthRisk = Read.HealthRisks.HealthRisk;

namespace Rules.HealthRisks
{
    public class IsHealthRiskExisting : IRuleImplementationFor<Domain.HealthRisks.IsHealthRiskExisting>
    {
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public IsHealthRiskExisting(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public Domain.HealthRisks.IsHealthRiskExisting Rule => healthRiskId => _healthRisks.GetById(healthRiskId) != null;
    }
}
