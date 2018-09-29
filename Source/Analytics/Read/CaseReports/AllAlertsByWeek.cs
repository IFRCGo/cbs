using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class AllAlertsByWeek : IQueryFor<AlertsByWeek>
    {
        readonly IReadModelRepositoryFor<AlertsByWeek> _repository;

        public AllAlertsByWeek(IReadModelRepositoryFor<AlertsByWeek> repository)
        {
            _repository = repository;
        }

        public IQueryable<AlertsByWeek> Query
        {
            get
            {
                return _repository.Query ;
            }
        }
    }
}
