/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Users
{
    public class AllUsers : IQueryFor<User>
    {
        readonly IReadModelRepositoryFor<User> _collection;

        public AllUsers(IReadModelRepositoryFor <User> collection)
        {
            _collection = collection;
        }

        public IQueryable<User> Query => _collection.Query;
    }
}