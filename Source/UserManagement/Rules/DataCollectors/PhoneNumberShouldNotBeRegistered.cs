using System.Linq;
using Dolittle.ReadModels;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class PhoneNumberShouldNotBeRegistered : IRuleImplementationFor<Domain.DataCollectors.PhoneNumberShouldNotBeRegistered>
    {
        readonly IReadModelRepositoryFor<DataCollector> _repository;
        public PhoneNumberShouldNotBeRegistered(IReadModelRepositoryFor<DataCollector> repository) => _repository = repository;

        public Domain.DataCollectors.PhoneNumberShouldNotBeRegistered Rule => (number) => !_repository.Query.SelectMany(_ => _.PhoneNumbers).Any(_ => _.Value == number);
    }
}