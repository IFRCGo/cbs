/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Management.DataCollectors
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        readonly IReadModelRepositoryFor<DataCollector> _repository;
        public AllDataCollectors(IReadModelRepositoryFor<DataCollector> repository)
        {
            _repository = repository;
        }

        public IQueryable<DataCollector> Query => _repository.Query;        
    }
}