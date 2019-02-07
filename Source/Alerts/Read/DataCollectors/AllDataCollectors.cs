/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        private readonly IReadModelRepositoryFor<DataCollector> _collection;

        public AllDataCollectors(IReadModelRepositoryFor<DataCollector> collection)
        {
            _collection = collection;
        }

        public IQueryable<DataCollector> Query => _collection.Query;
    }
}