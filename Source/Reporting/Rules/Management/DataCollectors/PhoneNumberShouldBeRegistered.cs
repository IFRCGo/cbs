/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Management.DataCollectors;

namespace Rules.Management.DataCollectors
{
    public class PhoneNumberShouldBeRegistered : IRuleImplementationFor<Domain.Management.DataCollectors.PhoneNumberShouldBeRegistered>
    {
        readonly IReadModelRepositoryFor<DataCollector> _repository;
        public PhoneNumberShouldBeRegistered(IReadModelRepositoryFor<DataCollector> repository) => _repository = repository;

        public Domain.Management.DataCollectors.PhoneNumberShouldBeRegistered Rule => (number) => _repository.Query.SelectMany(_ => _.PhoneNumbers).Any(_ => _.Value == number);
    }
}