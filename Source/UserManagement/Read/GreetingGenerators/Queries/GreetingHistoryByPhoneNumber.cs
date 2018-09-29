using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.GreetingGenerators.Queries
{
    public class GreetingHistoryByPhoneNumber : IQueryFor<GreetingHistory>
    {
        private readonly IGreetingHistories _repository;


        public string PhoneNumber { get; set; }
        public GreetingHistoryByPhoneNumber(IGreetingHistories repository)
        {
            _repository = repository;
        }


        public IQueryable<GreetingHistory> Query => _repository.Query.Where(g => g.PhoneNumber.Equals(PhoneNumber));

    }
}