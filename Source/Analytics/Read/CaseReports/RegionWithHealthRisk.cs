using Dolittle.ReadModels;
using Concepts;

namespace Read.CaseReports
{
    public class RegionWithHealthRisk : IReadModel
    {
        public Region Id;

        public NumberOfPeople NumCases;
    }
}
