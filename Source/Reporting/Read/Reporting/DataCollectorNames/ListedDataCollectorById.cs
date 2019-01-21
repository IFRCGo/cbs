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
    public class ListedDataCollectorById : IQueryFor<ListedDataCollector>
    {
        readonly IReadModelRepositoryFor<ListedDataCollector> _collection;

        public DataCollectorId DataCollectorId { get; set; }

        public ListedDataCollectorById(IReadModelRepositoryFor<ListedDataCollector> collection)
        {
            _collection = collection;
        }

        public IQueryable<ListedDataCollector> Query => _collection.Query.Where(d => d.Id == DataCollectorId);
    }
}