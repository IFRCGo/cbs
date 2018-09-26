using System.Linq;
using Dolittle.Queries;

namespace Read.GreetingGenerators.Queries
{
    public class AllGreetingHistories : IQueryFor<GreetingHistory>
    {
        private readonly IGreetingHistories _repository;

        public AllGreetingHistories(IGreetingHistories repository)
        {
            _repository = repository;
        }

        public IQueryable<GreetingHistory> Query => _repository.Query.Where(_ => true);

    }
}
