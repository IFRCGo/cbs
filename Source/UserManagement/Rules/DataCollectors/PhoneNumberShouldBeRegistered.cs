using System.Linq;
using Dolittle.ReadModels;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class PhoneNumberShouldBeRegistered : IRuleImplementationFor<Domain.DataCollectors.PhoneNumberShouldBeRegistered>
    {
        readonly IReadModelRepositoryFor<DataCollector> _repository;
        public PhoneNumberShouldBeRegistered(IReadModelRepositoryFor<DataCollector> repository) => _repository = repository;

        public Domain.DataCollectors.PhoneNumberShouldBeRegistered Rule => (number) => _repository.Query.SelectMany(_ => _.PhoneNumbers).Any(_ => _.Value == number);
    }
}