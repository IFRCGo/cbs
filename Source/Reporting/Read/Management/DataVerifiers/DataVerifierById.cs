/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.DataCollectors;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Management.DataVerifiers
{
    public class DataVerifierById : IQueryFor<DataVerifier>
    {
        readonly IReadModelRepositoryFor<DataVerifier> _repository;

        public DataCollectorId DataVerifierId { get; set; }

        public DataVerifierById(IReadModelRepositoryFor<DataVerifier> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<DataVerifier> Query => _repository.Query.Where(d => d.Id == DataVerifierId);
    }
}