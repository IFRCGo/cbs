/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class AllHealthRisks : IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repository;

        public AllHealthRisks(IReadModelRepositoryFor<HealthRisk> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<HealthRisk> Query => _repository.Query.Where(_ => true);
    }
}