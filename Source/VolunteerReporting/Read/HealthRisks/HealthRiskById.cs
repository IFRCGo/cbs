/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.HealthRisk;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class HealthRiskById : IQueryFor<HealthRisk>
    {
        private readonly IReadModelRepositoryFor<HealthRisk> _collection;

        public HealthRiskId HealthRiskId { get; set; }

        public HealthRiskById(IReadModelRepositoryFor<HealthRisk> collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query.Where(h => h.Id == HealthRiskId);
    }
}