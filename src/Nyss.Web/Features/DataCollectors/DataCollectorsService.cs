using System.Collections.Generic;
using RandomNameGeneratorLibrary;

namespace Nyss.Web.Features.DataCollectors
{
    public class DataCollectorsService : IDataCollectorsService
    {
        public IEnumerable<DataCollectorViewModel> All()
        {
            var personGenerator = new PersonNameGenerator();

            var dataCollectors = new List<DataCollectorViewModel>();
            for (var i = 0; i < 100; ++i)
            {
                dataCollectors.Add(new DataCollectorViewModel
                {
                    DisplayName = personGenerator.GenerateRandomFirstAndLastName()
                });
            }
            return dataCollectors;
        }
    }
}