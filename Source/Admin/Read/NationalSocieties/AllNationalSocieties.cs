/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.NationalSocieties
{
    public class AllNationalSocieties : IQueryFor<NationalSociety>
    {
        readonly IReadModelRepositoryFor<NationalSociety> _collection;

        public AllNationalSocieties(IReadModelRepositoryFor<NationalSociety> collection)
        {
            _collection = collection;
        }

        public IQueryable<NationalSociety> Query => _collection.Query;
    }
}