/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.DataCollector;
using Dolittle.Queries;

namespace Read.DataCollectors
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _collection;

        public DataCollectorId DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors collection)
        {
            _collection = collection;
        }

        public IQueryable<DataCollector> Query => _collection.Query.Where(d => d.Id == DataCollectorId);
    }
}