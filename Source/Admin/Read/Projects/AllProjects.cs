/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class AllProjects : IQueryFor<Project>
    {
        private readonly IReadModelRepositoryFor<Project> _collection;

        public AllProjects(IReadModelRepositoryFor<Project> collection)
        {
            _collection = collection;
        }

        public IQueryable<Project> Query => _collection.Query;
    }
}