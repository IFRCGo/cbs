using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts.HealthRisk;

namespace Read.HealthRisk
{
    public class GetHealthRisks: IQueryFor<HealthRisks>
    {
        readonly IReadModelRepositoryFor<HealthRisks> _repositoryForHealthRisks;

        public ListId Id { get; set; } = ListId.None;

        public GetHealthRisks(IReadModelRepositoryFor<HealthRisks> repositoryForHealthRisks)
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }

        public IQueryable<HealthRisks> Query
        {
            get
            {
                return Id == ListId.None
                    ? new HealthRisks[0].AsQueryable()
                    : new [] 
                    {
                        _repositoryForHealthRisks
                        .Query
                        .FirstOrDefault(readModel => readModel.Id == Id)
                    }.AsQueryable();
            }
        }
    }
}
