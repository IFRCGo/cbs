using System.Collections.Generic;
using Dolittle.Queries;

namespace Read.GreetingGenerators
{
    public class GreetingProvider : IQueryProviderFor<GreetingHistory>
    {
        public QueryProviderResult Execute(GreetingHistory query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            if (query == null)
            {
                //Todo: Perhaps throw apropriate exception
                return result;
            }

            result.Items = new List<GreetingHistory> { query };

            result.TotalItems = 1;

            return result;
        }
    }
}