
using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Read.CaseReports;

namespace Read.AgeAndSexDistribution
{
    public class AgeAndSexDistributionAggregationByDateRange : IQueryFor<AgeAndSexDistribution>
    {
        private readonly IReadModelRepositoryFor<CaseReport> _repository;

        public AgeAndSexDistributionAggregationByDateRange(IReadModelRepositoryFor<CaseReport> repository)
        {
            _repository = repository;
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public IQueryable<AgeAndSexDistribution> Query => Build();

        IQueryable<AgeAndSexDistribution> Build()
        {
            var total = Aggregate(From,To);
            return new AgeAndSexDistribution[]{ total }.AsQueryable();
        }

        AgeAndSexDistribution Aggregate(DateTime from, DateTime to)
        {
            var matches = _repository.Query.Where(a => a.Timestamp >= from && a.Timestamp <= to);
            return new AgeAndSexDistribution
            {
                NumberOfFemalesAged5AndOlder = matches.Sum(a => a.NumberOfFemalesAged5AndOlder),
                NumberOfFemalesUnder5 = matches.Sum(a => a.NumberOfFemalesUnder5),
                NumberOfMalesAged5AndOlder = matches.Sum(a => a.NumberOfMalesAged5AndOlder),
                NumberOfMalesUnder5 = matches.Sum(a => a.NumberOfMalesUnder5),
                From = from,
                To = to
            };
        }
    }
} 
