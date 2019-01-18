/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.DataCollectors;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Reporting.DataCollectors
{
    public class DataCollectorById : IQueryFor<DataCollector_>
    {
        private readonly IReadModelRepositoryFor<DataCollector_> _collection;

        public DataCollectorId DataCollectorId { get; set; }

        public DataCollectorById(IReadModelRepositoryFor<DataCollector_> collection)
        {
            _collection = collection;
        }

        public IQueryable<DataCollector_> Query => _collection.Query.Where(d => d.Id == DataCollectorId);
    }
}