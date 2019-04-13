/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Alerts
{
    public class AllAlertOverviews : IQueryFor<AlertOverview>
    {
        private readonly IReadModelRepositoryFor<AlertOverview> _collection;

        public AllAlertOverviews(IReadModelRepositoryFor<AlertOverview> collection)
        {
            _collection = collection;
        }

        public IQueryable<AlertOverview> Query => _collection.Query;
    }
}