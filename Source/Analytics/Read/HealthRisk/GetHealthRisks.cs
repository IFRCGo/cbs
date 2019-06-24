using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts.HealthRisk;

namespace Read.HealthRisk
{
    public class GetHealthRisks: IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisks;

        public ListId Id { get; set; } = ListId.None;

        public GetHealthRisks(IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisks)
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }

        public IQueryable<HealthRisk> Query
        {
            get
            {
                return new [] 
                    {
                        _repositoryForHealthRisks
                        .Query
                        .FirstOrDefault()
                    }.AsQueryable();
            }
        }
    }
}
