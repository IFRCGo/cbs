using System.Collections.Generic;

namespace Nyss.Web.Features.DataCollectors
{
    public interface IDataCollectorsService
    {
        IEnumerable<DataCollectorViewModel> All();
    }
}
