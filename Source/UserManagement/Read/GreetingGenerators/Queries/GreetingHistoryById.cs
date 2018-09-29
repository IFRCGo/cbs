using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.GreetingGenerators.Queries
{
    public class GreetingHistoryById : IQueryFor<GreetingHistory>
    {
        private readonly IGreetingHistories _repository;

        public Guid DataCollectorId { get; set; }

        public GreetingHistoryById(IGreetingHistories repository)
        {
            _repository = repository;
        }


        public IQueryable<GreetingHistory> Query => _repository.Query.Where(g => g.Id == DataCollectorId);

    }
}