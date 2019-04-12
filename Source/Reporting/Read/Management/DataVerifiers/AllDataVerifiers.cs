/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Management.DataVerifiers
{
    public class AllDataVerifiers : IQueryFor<DataVerifier>
    {
        readonly IReadModelRepositoryFor<DataVerifier> _repository;
        public AllDataVerifiers(IReadModelRepositoryFor<DataVerifier> repository)
        {
            _repository = repository;
        }

        public IQueryable<DataVerifier> Query => _repository.Query;        
    }
}