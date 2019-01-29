/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.DataCollectors;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Management.DataCollectors
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        readonly IReadModelRepositoryFor<DataCollector> _repository;

        public DataCollectorId DataCollectorId { get; set; }

        public DataCollectorById(IReadModelRepositoryFor<DataCollector> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<DataCollector> Query => _repository.Query.Where(d => d.Id == DataCollectorId);
    }
}