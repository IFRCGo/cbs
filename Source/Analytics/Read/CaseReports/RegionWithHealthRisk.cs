using Dolittle.ReadModels;
using Concepts;

namespace Read.CaseReports
{
    public class RegionWithHealthRisk : IReadModel
    {
        public RegionName Id;

        public NumberOfPeople NumCases;
    }
}
